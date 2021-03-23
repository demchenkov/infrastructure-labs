import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { finalize, map, mergeMap, share, tap } from 'rxjs/operators';
import { Customer } from 'src/app/domain/entities';


@Injectable()
export class CustomersApiService {
  static readonly URL = '/api/customers';
  
  private entitiesSubj$ = new BehaviorSubject<Customer[]>([]);
  private loadingSubj$ = new BehaviorSubject<boolean>(true);

  public entities$ = this.entitiesSubj$.asObservable().pipe(map(x => x.sort((a, b) => a.id.localeCompare(b.id))));
  public loading$ = this.loadingSubj$.asObservable();

  constructor(private http: HttpClient) { }

  loadAll(isDone?: boolean, isPayment?: boolean): Observable<Array<Customer>> {
    this.loadingSubj$.next(true);
    const observable = this.http.get<any[]>(`${CustomersApiService.URL}?isDone=${isDone}&isPayment=${isPayment}`).pipe(
      share(),
      map(x => x.map(it => Customer.fromJS(it))),
      tap(x => this.entitiesSubj$.next(x)),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  getById(id: number): Observable<Customer> {
    const observable = this.http.get(`${CustomersApiService.URL}/${id}`).pipe(
      share(),
      map(x => Customer.fromJS(x)),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  create(entity: Partial<Customer>): Observable<Customer> {
    this.loadingSubj$.next(true);
    const observable = this.http.post<any>(CustomersApiService.URL, entity).pipe(
      share(),
      mergeMap(x => this.http.get(`${CustomersApiService.URL}/${x.id}`)),
      map(x => Customer.fromJS(x)),
      tap(x => this.entitiesSubj$.next([...this.entitiesSubj$.value, x])),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  update(id: string, entity: Partial<Customer>): Observable<Customer> {
    const observable = this.http.put<any>(`${CustomersApiService.URL}/${id}`, entity).pipe(
      share(),
      mergeMap(() => this.http.get(`${CustomersApiService.URL}/${id}`)),
      map(x => Customer.fromJS(x)),
      tap(x => this.entitiesSubj$.next([...this.entitiesSubj$.value.filter(e => e.id !== x.id), x])),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }

  delete(id: string): Observable<void> {
    const observable = this.http.delete<void>(`${CustomersApiService.URL}/${id}`).pipe(
      share(),
      map(() => {}),
      tap(() => this.entitiesSubj$.next([...this.entitiesSubj$.value.filter(x => x.id !== id)])),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }
}
