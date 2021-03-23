import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import {ApiAuthorizationModule} from "./core/api-authorization/api-authorization.module";
import { AuthorizeGuard } from './core/api-authorization/authorize.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'cars',
    pathMatch: 'full'
  },
  {
    path: 'about',
    loadChildren: () =>
      import('./features/about/about.module').then((m) => m.AboutModule)
  },
  {
    path: 'cars',
    loadChildren: () =>
      import('./features/cars/cars.module').then((m) => m.CarsModule),
    canActivate: []
  },
  
  {
    path: 'customers',
    loadChildren: () =>
      import('./features/customers/customers.module').then((m) => m.CustomersModule),
    canActivate: [AuthorizeGuard]
  },
  
  {
    path: 'employees',
    loadChildren: () =>
      import('./features/employees/employees.module').then((m) => m.EmployeesModule),
    canActivate: [AuthorizeGuard]
  },
  {
    path: '**',
    redirectTo: 'cars'
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'enabled',
      preloadingStrategy: PreloadAllModules,
      relativeLinkResolution: 'legacy'
    }),
    ApiAuthorizationModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
