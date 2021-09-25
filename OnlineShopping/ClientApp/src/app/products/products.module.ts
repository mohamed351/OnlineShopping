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
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { ProductInfoComponent } from './product-info/product-info.component';

@NgModule({
  declarations: [ProductListComponent, ProductCategoryComponent, ShoppingCartComponent, ProductInfoComponent],
  imports: [
    CommonModule,
    ProductRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatGridListModule

  ],
  providers:[
    ProductResolverService,
    ProductService
  ]

})
export class ProductsModule { }
