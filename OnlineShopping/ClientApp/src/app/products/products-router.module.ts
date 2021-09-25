import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductCategoryComponent } from './product-category/product-category.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductResolverService } from './services/product-resolver.';
import {ShoppingCartComponent} from './shopping-cart/shopping-cart.component';
import {ProductInfoComponent} from './product-info/product-info.component';
const router:Routes =[
  {path:"" , component:ProductCategoryComponent , resolve:{data:ProductResolverService}},
  {path:"cart",component:ShoppingCartComponent},
  {path:":id" , component:ProductCategoryComponent , resolve:{data:ProductResolverService}},
  {path:"product/:id", component:ProductInfoComponent}

]

const routes: Routes = [
  {
    path: '',
    component: ProductListComponent,
    children:router

  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule {}
