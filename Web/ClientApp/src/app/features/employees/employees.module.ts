import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeesRoutingModule } from './employees-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { UiModalModule } from 'src/app/core/modules';
import { MatDialogModule } from '@angular/material/dialog';
import { PositionsApiService } from 'src/app/domain/services';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { EmployeeListPageComponent } from './containers/employee-list-page/employee-list-page.component';
import { EmployeeEditModalComponent } from './components/employee-edit-modal/employee-edit-modal.component';


@NgModule({
  declarations: [EmployeeListPageComponent, EmployeeEditModalComponent],
  imports: [
    CommonModule,
    EmployeesRoutingModule,
    FormsModule,
    HttpClientModule,
    MatTableModule,
    MatListModule,
    MatSortModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    MatSlideToggleModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatButtonToggleModule,
    MatButtonModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatDialogModule,
    ReactiveFormsModule,
    UiModalModule
  ],
  providers: [PositionsApiService]
})
export class EmployeesModule { }
