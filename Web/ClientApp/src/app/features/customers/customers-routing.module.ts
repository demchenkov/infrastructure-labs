import { NgModule } from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import { CustomerListPageComponent } from './containers/customer-list-page/customer-list-page.component';

const routes: Routes = [
  {
    path: '',
    component: CustomerListPageComponent,
    data: { title: 'Customers' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
