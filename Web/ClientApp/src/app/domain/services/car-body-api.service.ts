import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { finalize, map, share, tap } from 'rxjs/operators';
import { CarBody } from 'src/app/domain/entities';


@Injectable()
export class CarBodiesApiService {
  static readonly URL = '/api/car-bodies';
  
  private entitiesSubj$ = new BehaviorSubject<CarBody[]>([]);
  private loadingSubj$ = new BehaviorSubject<boolean>(true);

  public entities$ = this.entitiesSubj$.asObservable().pipe(map(x => x.sort((a, b) => a.id - b.id)));
  public loading$ = this.loadingSubj$.asObservable();

  constructor(private http: HttpClient) { }

  loadAll(): Observable<Array<CarBody>> {
    this.loadingSubj$.next(true);
    const observable = this.http.get<any[]>(CarBodiesApiService.URL).pipe(
      share(),
      map(x => x.map(it => CarBody.fromJS(it))),
      tap(x => this.entitiesSubj$.next(x)),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }
}
