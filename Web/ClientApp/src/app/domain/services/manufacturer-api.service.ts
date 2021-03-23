import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { finalize, map, share, tap } from 'rxjs/operators';
import { Manufacturer } from 'src/app/domain/entities';


@Injectable()
export class ManufacturersApiService {
  static readonly URL = '/api/manufacturers';
  
  private entitiesSubj$ = new BehaviorSubject<Manufacturer[]>([]);
  private loadingSubj$ = new BehaviorSubject<boolean>(true);

  public entities$ = this.entitiesSubj$.asObservable().pipe(map(x => x.sort((a, b) => a.id - b.id)));
  public loading$ = this.loadingSubj$.asObservable();

  constructor(private http: HttpClient) { }

  loadAll(): Observable<Array<Manufacturer>> {
    this.loadingSubj$.next(true);
    const observable = this.http.get<any[]>(ManufacturersApiService.URL).pipe(
      share(),
      map(x => x.map(it => Manufacturer.fromJS(it))),
      tap(x => this.entitiesSubj$.next(x)),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }
}
