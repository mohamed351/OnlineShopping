import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductCategoryComponent } from './product-category/product-category.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductResolverService } from './services/product-resolver.';

const router:Routes =[
  {path:"" , component:ProductCategoryComponent , resolve:{data:ProductResolverService}},
  {path:":id" , component:ProductCategoryComponent , resolve:{data:ProductResolverService}}
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
