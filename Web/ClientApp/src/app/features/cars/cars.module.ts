import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarRoutingModule } from './cars-routing.module';
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
import { CarListPageComponent } from './containers/car-list-page/car-list-page.component';
import { CarEditModalComponent } from './components/car-edit-modal/car-edit-modal.component';
import { UiModalModule } from 'src/app/core/modules';
import { MatDialogModule } from '@angular/material/dialog';
import { CarBodiesApiService, EmployeesApiService, EquipmentsApiService, ManufacturersApiService } from 'src/app/domain/services';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';


@NgModule({
  declarations: [CarListPageComponent, CarEditModalComponent],
  imports: [
    CommonModule,
    CarRoutingModule,
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
    MatCheckboxModule,
    MatDatepickerModule,
    MatDialogModule,
    ReactiveFormsModule,
    UiModalModule
  ],
  providers: [CarBodiesApiService, ManufacturersApiService, EquipmentsApiService, EmployeesApiService]
})
export class CarsModule { }
