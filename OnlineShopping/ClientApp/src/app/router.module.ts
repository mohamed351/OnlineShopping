import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {BaseLayoutComponent} from './shared/layouts/base-layout/base-layout.component';

const baseLayoutRouting: Routes = [
  {
    path:"",
    loadChildren:()=>import("./home/home.module").then(m => m.HomeModule)
  }

];

const routes: Routes = [
  {
    path: '',
    component: BaseLayoutComponent,
    children: baseLayoutRouting
  },


];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'enabled'
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
