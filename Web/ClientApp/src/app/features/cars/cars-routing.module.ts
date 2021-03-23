import { NgModule } from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import { CarListPageComponent } from './containers/car-list-page/car-list-page.component';

const routes: Routes = [
  {
    path: '',
    component: CarListPageComponent,
    data: { title: 'Cars' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarRoutingModule { }
