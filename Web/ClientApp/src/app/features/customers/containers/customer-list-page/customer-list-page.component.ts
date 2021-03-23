import { KeyValue } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { combineLatest } from 'rxjs';
import { filter, map, switchMap, take } from 'rxjs/operators';
import { ConfirmService } from 'src/app/core/confirm/confirm.service';
import { Customer } from 'src/app/domain/entities';
import { CarsApiService, CustomersApiService, EmployeesApiService, EquipmentsApiService, ManufacturersApiService } from 'src/app/domain/services';
import { CustomersEditModalComponent, EditCustomerData } from '../../components/customers-edit-modal/customers-edit-modal.component';

@Component({
  selector: 'sb-Customer-list-page',
  templateUrl: './customer-list-page.component.html',
  styleUrls: ['./customer-list-page.component.scss'],
  providers: [CustomersApiService],
})
export class CustomerListPageComponent implements OnInit {
  displayedColumns: string[] = [
    'name', 'address', 'phone', 'passport', 'orderDate', 
    'saleDate', 'isDone', 'isPayment', 'prepaymentPercentage', 'car', 'employee',
    'actions'
  ];
  isLoading$ = this.isLoading();
  data$ = this.service.entities$;
  form: FormGroup;

  constructor(
    private service: CustomersApiService, 
    private carsService: CarsApiService, 
    private employeesApiService: EmployeesApiService,
    private dialog: MatDialog,
    private confirmService: ConfirmService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.service.loadAll();
    this.carsService.loadAll();
    this.employeesApiService.loadAll();

    this.form = this.fb.group({
      showAll: [true],
      isPayment: [false],
      isDone: [false] 
    });

    this.form.valueChanges.subscribe(x => {
      if (x.showAll)
        this.service.loadAll();
      else this.service.loadAll(x.isDone, x.isPayment);
    });
  }

  addNew() {
    this.openEditModal(null)
      .subscribe(entity => {
        this.service.create(entity);
      });
  }

  editRow(index: number, item: Customer) {
    this.openEditModal(item)
      .subscribe(entity => {
        this.service.update(item.id, entity);
      });
  }

  deleteRow(index: number, entity: Customer) {
    this.confirmService.confirm({
      title: 'Delete Curve',
      template: [`Are you sure you  want to delete this Customer ?`],
      confirmText: 'Delete',
      cancelText: 'Cancel'
    }, {
      width: '448px'
    })
    .subscribe(() => this.service.delete(entity.id));
  }


  getLink(row: Customer): string {
    return `./${row.id}`;
  }

  private openEditModal(entity: Customer | null) {
    return combineLatest([
      this.carsService.entities$,
      this.employeesApiService.entities$,
    ]).pipe(
      map(([cars, employees]) => {
        return [
          cars.map(x => ({key: x.id, value: x.bodyNumber} as KeyValue<number, string>)), 
          employees.map(x => ({key: x.id, value: x.fullName} as KeyValue<number, string>))];
      }),
      switchMap(([cars, employees]) => {
        const dialogRef = this.dialog.open(CustomersEditModalComponent, {
          data: { entity, cars, employees } as EditCustomerData,
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
      this.carsService.loading$,
      this.employeesApiService.loading$,
    ]).pipe(map(([customersLoading, carsLoading, employeesLoading]) => 
      customersLoading || carsLoading || employeesLoading
    ));
  }

}
