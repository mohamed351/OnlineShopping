import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ProductRoutingModule} from './products-router.module';
import { ProductService } from '../services/product.service';
import { ProductResolverService } from './services/product-resolver.';
import {ProductListComponent} from './product-list/product-list.component';
import { ProductCategoryComponent } from './product-category/product-category.component';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatIcon} from '@angular/material/icon';

@NgModule({
  declarations: [ProductListComponent, ProductCategoryComponent],
  imports: [
    CommonModule,
    ProductRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatGridListModule

  ],
  providers:[
    ProductResolverService
  ]

})
export class ProductsModule { }
