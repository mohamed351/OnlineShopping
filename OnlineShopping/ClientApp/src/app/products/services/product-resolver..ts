import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import { ProductCategory } from '../../models/productCategory';

@Injectable({
  providedIn: 'root'
})
export class ProductResolverService implements Resolve<ProductCategory[]> {

  constructor(private productService:ProductService) { }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): ProductCategory[] | Observable<ProductCategory[]> | Promise<ProductCategory[]> {
    console.log(route.params["id"]);
   if(route.params["id"]){
    return this.productService.GetProductByCategory(+route.params["id"]);
   }
   else{
    return this.productService.GetAll();
   }
  }
}

