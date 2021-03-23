import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { finalize, map, mergeMap, share, tap } from 'rxjs/operators';
import { Car } from 'src/app/domain/entities';


@Injectable()
export class CarsApiService {
  static readonly URL = '/api/cars';
  
  private entitiesSubj$ = new BehaviorSubject<Car[]>([]);
  private loadingSubj$ = new BehaviorSubject<boolean>(true);

  public entities$ = this.entitiesSubj$.asObservable().pipe(map(x => x.sort((a, b) => a.id - b.id)));
  public loading$ = this.loadingSubj$.asObservable();

  constructor(private http: HttpClient) { }

  loadAll(employeeId?: number, carBodyId?: number): Observable<Array<Car>> {
    this.loadingSubj$.next(true);
    const observable = this.http.get<any[]>(`${CarsApiService.URL}?employeeId=${employeeId}&carBodyId=${carBodyId}`).pipe(
      share(),
      map(x => x.map(it => Car.fromJS(it))),
      tap(x => this.entitiesSubj$.next(x)),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  getById(id: number): Observable<Car> {
    const observable = this.http.get(`${CarsApiService.URL}/${id}`).pipe(
      share(),
      map(x => Car.fromJS(x)),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  create(entity: Partial<Car>): Observable<Car> {
    this.loadingSubj$.next(true);
    const observable = this.http.post<any>(CarsApiService.URL, entity).pipe(
      share(),
      mergeMap(x => this.http.get(`${CarsApiService.URL}/${x.id}`)),
      map(x => Car.fromJS(x)),
      tap(x => this.entitiesSubj$.next([...this.entitiesSubj$.value, x])),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  update(id: number, entity: Partial<Car>): Observable<Car> {
    const observable = this.http.put<any>(`${CarsApiService.URL}/${id}`, entity).pipe(
      share(),
      mergeMap(() => this.http.get(`${CarsApiService.URL}/${id}`)),
      map(x => Car.fromJS(x)),
      tap(x => this.entitiesSubj$.next([...this.entitiesSubj$.value.filter(e => e.id !== x.id), x])),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  delete(id: number): Observable<void> {
    const observable = this.http.delete<void>(`${CarsApiService.URL}/${id}`).pipe(
      share(),
      map(() => {}),
      tap(() => this.entitiesSubj$.next([...this.entitiesSubj$.value.filter(x => x.id !== id)])),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }
}
