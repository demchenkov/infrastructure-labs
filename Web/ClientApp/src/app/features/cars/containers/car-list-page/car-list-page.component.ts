import { KeyValue } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { combineLatest } from 'rxjs';
import { filter, map, switchMap, take, tap } from 'rxjs/operators';
import { ConfirmService } from 'src/app/core/confirm/confirm.service';
import { Car } from 'src/app/domain/entities';
import { CarBodiesApiService, CarsApiService, EmployeesApiService, EquipmentsApiService, ManufacturersApiService } from 'src/app/domain/services';
import { CarEditModalComponent, EditCarData } from '../../components/car-edit-modal/car-edit-modal.component';

@Component({
  selector: 'sb-car-list-page',
  templateUrl: './car-list-page.component.html',
  styleUrls: ['./car-list-page.component.scss'],
  providers: [CarsApiService],
})
export class CarListPageComponent implements OnInit {
  displayedColumns: string[] = [
    'id', 'brand', 'manufactureDate', 'color', 'bodyNumber', 
     /*'characteristics', */ 'price', 'carBody', 'manufacturer', 
    'equipment1', 'equipment2', 'equipment3', 'employee',  
    'actions'
  ];
  isLoading$ = this.isLoading();
  data$ = this.service.entities$;
  employees$ = this.employeesApiService.entities$;
  bodies$ = this.carBodiesApiService.entities$;
  form: FormGroup;

  constructor(
    private service: CarsApiService, 
    private carBodiesApiService: CarBodiesApiService, 
    private manufacturersApiService: ManufacturersApiService, 
    private equipmentsApiService: EquipmentsApiService, 
    private employeesApiService: EmployeesApiService,
    private dialog: MatDialog,
    private confirmService: ConfirmService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.service.loadAll();
    this.carBodiesApiService.loadAll();
    this.manufacturersApiService.loadAll();
    this.equipmentsApiService.loadAll();
    this.employeesApiService.loadAll();

    this.form = this.fb.group({
      showAll: [true],
      employeeId: [0],
      carBodyId: [0] 
    });

    this.form.valueChanges.subscribe(x => {
      if (x.showAll)
        this.service.loadAll();
      else this.service.loadAll(x.employeeId, x.carBodyId);
    });
  }

  addNew() {
    this.openEditModal(null)
      .subscribe(entity => {
        this.service.create(entity);
      });
  }

  editRow(index: number, item: Car) {
    this.openEditModal(item)
      .subscribe(entity => {
        this.service.update(item.id, entity);
      });
  }

  deleteRow(index: number, entity: Car) {
    this.confirmService.confirm({
      title: 'Delete Curve',
      template: [`Are you sure you  want to delete this car ?`],
      confirmText: 'Delete',
      cancelText: 'Cancel'
    }, {
      width: '448px'
    })
    .subscribe(() => this.service.delete(entity.id));
  }


  getLink(row: Car): string {
    return `./${row.id}`;
  }

  private openEditModal(entity: Car | null) {
    return combineLatest([
      this.carBodiesApiService.entities$,
      this.manufacturersApiService.entities$,
      this.equipmentsApiService.entities$,
      this.employeesApiService.entities$,
    ]).pipe(
      map(([bodies, manufacturers, equipments, employees]) => {
        return [
          bodies.map(x => ({key: x.id, value: x.name} as KeyValue<number, string>)), 
          manufacturers.map(x => ({key: x.id, value: x.name} as KeyValue<number, string>)), 
          equipments.map(x => ({key: x.id, value: x.name} as KeyValue<number, string>)), 
          employees.map(x => ({key: x.id, value: x.fullName} as KeyValue<number, string>))];
      }),
      switchMap(([bodies, manufacturers, equipments, employees]) => {
        const dialogRef = this.dialog.open(CarEditModalComponent, {
          data: { entity, bodies, manufacturers, equipments, employees } as EditCarData,
          width: '448px'
        });
        return dialogRef.afterClosed()
      }),
      take(1), 
      filter(Boolean),
    )
  }

  private isLoading() {
    return combineLatest([
      this.service.loading$, 
      this.carBodiesApiService.loading$,
      this.manufacturersApiService.loading$,
      this.equipmentsApiService.loading$,
      this.employeesApiService.loading$,
    ]).pipe(map(([carsLoading, carBodiesLoading, manufacturersLoading, equipmentsLoading, employeesLoading]) => 
      carsLoading || carBodiesLoading || manufacturersLoading || equipmentsLoading || employeesLoading
    ));
  }

}
