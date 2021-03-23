import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { finalize, map, share, tap } from 'rxjs/operators';
import { Equipment } from 'src/app/domain/entities';


@Injectable()
export class EquipmentsApiService {
  static readonly URL = '/api/equipments';
  
  private entitiesSubj$ = new BehaviorSubject<Equipment[]>([]);
  private loadingSubj$ = new BehaviorSubject<boolean>(true);

  public entities$ = this.entitiesSubj$.asObservable().pipe(map(x => x.sort((a, b) => a.id - b.id)));
  public loading$ = this.loadingSubj$.asObservable();

  constructor(private http: HttpClient) { }

  loadAll(): Observable<Array<Equipment>> {
    this.loadingSubj$.next(true);
    const observable = this.http.get<any[]>(EquipmentsApiService.URL).pipe(
      share(),
      map(x => x.map(it => Equipment.fromJS(it))),
      tap(x => this.entitiesSubj$.next(x)),
      finalize(() => this.loadingSubj$.next(false))
    );

    observable.subscribe();
    return observable;
  }
}
