import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { finalize, map, mergeMap, share, tap } from 'rxjs/operators';
import { Employee } from 'src/app/domain/entities';


@Injectable()
export class EmployeesApiService {
  static readonly URL = '/api/employees';
  
  private entitiesSubj$ = new BehaviorSubject<Employee[]>([]);
  private loadingSubj$ = new BehaviorSubject<boolean>(true);

  public entities$ = this.entitiesSubj$.asObservable().pipe(map(x => x.sort((a, b) => a.id - b.id)));
  public loading$ = this.loadingSubj$.asObservable();

  constructor(private http: HttpClient) { }

  loadAll(): Observable<Array<Employee>> {
    this.loadingSubj$.next(true);
    const observable = this.http.get<any[]>(EmployeesApiService.URL).pipe(
      share(),
      map(x => x.map(it => Employee.fromJS(it))),
      tap(x => this.entitiesSubj$.next(x)),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  getById(id: number): Observable<Employee> {
    const observable = this.http.get(`${EmployeesApiService.URL}/${id}`).pipe(
      share(),
      map(x => Employee.fromJS(x)),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  create(entity: Partial<Employee>): Observable<Employee> {
    this.loadingSubj$.next(true);
    const observable = this.http.post<any>(EmployeesApiService.URL, entity).pipe(
      share(),
      mergeMap(x => this.http.get(`${EmployeesApiService.URL}/${x.id}`)),
      map(x => Employee.fromJS(x)),
      tap(x => this.entitiesSubj$.next([...this.entitiesSubj$.value, x])),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  update(id: number, entity: Partial<Employee>): Observable<Employee> {
    const observable = this.http.put<any>(`${EmployeesApiService.URL}/${id}`, entity).pipe(
      share(),
      mergeMap(() => this.http.get(`${EmployeesApiService.URL}/${id}`)),
      map(x => Employee.fromJS(x)),
      tap(x => this.entitiesSubj$.next([...this.entitiesSubj$.value.filter(e => e.id !== x.id), x])),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  delete(id: number): Observable<void> {
    const observable = this.http.delete<void>(`${EmployeesApiService.URL}/${id}`).pipe(
      share(),
      map(() => {}),
      tap(() => this.entitiesSubj$.next([...this.entitiesSubj$.value.filter(x => x.id !== id)])),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }
}
