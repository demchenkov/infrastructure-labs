import { KeyValue } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { combineLatest } from 'rxjs';
import { filter, map, switchMap, take } from 'rxjs/operators';
import { ConfirmService } from 'src/app/core/confirm/confirm.service';
import { Employee } from 'src/app/domain/entities';
import { EmployeesApiService, PositionsApiService } from 'src/app/domain/services';
import { EmployeeEditModalComponent, EditEmployeeData } from '../../components/employee-edit-modal/employee-edit-modal.component';

@Component({
  selector: 'sb-employee-list-page',
  templateUrl: './employee-list-page.component.html',
  styleUrls: ['./employee-list-page.component.scss'],
  providers: [EmployeesApiService],
})
export class EmployeeListPageComponent implements OnInit {
   displayedColumns: string[] = [
    'id', 'fullName', 'age', 'gender', 'address', 'phone', 'passport', 'position',  
    'actions'
  ];
  isLoading$ = this.isLoading();
  data$ = this.service.entities$; 

  constructor(
    private service: EmployeesApiService, 
    private positionService: PositionsApiService,
    private dialog: MatDialog,
    private confirmService: ConfirmService) { }

  ngOnInit(): void {
    this.service.loadAll();
    this.positionService.loadAll();
  }

  addNew() {
    this.openEditModal(null)
      .subscribe(entity => {
        this.service.create(entity);
      });
  }

  editRow(index: number, item: Employee) {
    this.openEditModal(item)
      .subscribe(entity => {
        this.service.update(item.id, entity);
      });
  }

  deleteRow(index: number, entity: Employee) {
    this.confirmService.confirm({
      title: 'Delete Curve',
      template: [`Are you sure you  want to delete this Employee ?`],
      confirmText: 'Delete',
      cancelText: 'Cancel'
    }, {
      width: '448px'
    })
    .subscribe(() => this.service.delete(entity.id));
  }


  getLink(row: Employee): string {
    return `./${row.id}`;
  }

  private openEditModal(entity: Employee | null) {
    return this.positionService.entities$.pipe(
      map(positions => positions.map(x => ({key: x.id, value: x.name} as KeyValue<number, string>))),
      switchMap(positions => {
        const dialogRef = this.dialog.open(EmployeeEditModalComponent, {
          data: { entity, positions } as EditEmployeeData,
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
      this.positionService.loading$,
    ]).pipe(map(([employeesLoading, positionsLoading]) => employeesLoading || positionsLoading));
  }

}
