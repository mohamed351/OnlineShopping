import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Products } from '../models/product';
import {ProductCategory} from '../models/productCategory';
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  public GetAll(){
    return this.http.get<ProductCategory[]>("/api/Products");
  }
  public GetProductByCategory(id:number){
    return this.http.get<ProductCategory[]>(`/api/Products/cateogry/${id}`);
  }


}
