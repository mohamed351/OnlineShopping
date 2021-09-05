import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {BaseLayoutComponent} from './shared/layouts/base-layout/base-layout.component';
import {ShoppingAppComponent} from './shared/layouts/shopping-app/shopping-app.component';
const baseLayoutRouting: Routes = [
  {
    path:"",
    loadChildren:()=>import("./home/home.module").then(m => m.HomeModule)
  }

];
const shoppingAppRouting:Routes=[
  {
    path:"",
    loadChildren:()=>import("./products/products.module").then(m=>m.ProductsModule)
  }
]

const routes: Routes = [
  {
    path: '',
    component: BaseLayoutComponent,
    children: baseLayoutRouting
  },
  {
    path:'authication',
    loadChildren:()=> import("./auth/auth.module").then(m=>m.AuthModule)
  },
  {
    path:"products",
    component:ShoppingAppComponent,
    children:shoppingAppRouting
  }


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
