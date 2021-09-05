import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ProductCategory } from '../models/productCategory';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  public subject:Subject<ProductCartElements[]> = new Subject<ProductCartElements[]>();
  constructor() { }

  addProductCart(productid:number, productName:string , productImage:string){
   if( localStorage.getItem("cart")){
    let  oldData:any[] = JSON.parse(  localStorage.getItem("cart"));
    let  oldProduct = oldData.find(a=>a.productid == productid);
    if(oldProduct){
      oldProduct.quantity++;
    }
    else{
      oldData.push({
    productid,
    productName,
    productImage,
    quantity:1
     });

    }

     localStorage.setItem("cart",JSON.stringify(oldData));
   }
   else{
     let newArray = [];
     newArray.push({
      productid,
      productName,
      productImage,
      quantity:1
     })
     localStorage.setItem("cart",JSON.stringify(newArray));
   }

  }

  cartCount():number{
    if( localStorage.getItem("cart")){
      let  oldData = JSON.parse(  localStorage.getItem("cart"));
      return oldData.length;
    }
    else{
      return 0;
    }
  }
  getCartElements():ProductCartElements[] |null{
    if(localStorage.getItem("cart")){
      return JSON.parse(localStorage.getItem("cart"));
    }
    else{
      return null;
    }
  }
  Increse(productId:number){
  let productArray =  JSON.parse( localStorage.getItem("cart"));
   let newData =JSON.stringify(  productArray.map(a=> a.productid == productId ? {...a,quantity:a.quantity +1 }:a));
    localStorage.setItem("cart",newData);
    this.subject.next(JSON.parse(localStorage.getItem("cart")));
  }
  decrese(productId:number){
    let productArray =  JSON.parse( localStorage.getItem("cart"));
     let newData:ProductCartElements[] =  productArray.map(a=> a.productid == productId ? {...a,quantity:  a.quantity -1 }:a);
     if( newData.find(a=>a.productid == productId).quantity == 0){
       newData = newData.filter(a=>a.productid != productId);
     }

      localStorage.setItem("cart",JSON.stringify(newData));

      this.subject.next(JSON.parse(localStorage.getItem("cart")));
  }
  setPriceToLocalStorageWhenQuery(data:any){
    localStorage.setItem("cart",JSON.stringify( data));
  }

}
export interface ProductCartElements{
  productid:number;
  productName:string;
  productImage:string;
  quantity:number;
  price:number |null;
}
