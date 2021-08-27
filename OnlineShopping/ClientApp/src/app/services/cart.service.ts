import { Injectable } from '@angular/core';
import { ProductCategory } from '../models/productCategory';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor() { }

  addProductCart(productid:number, productName:string , productImage:string){
   if( localStorage.getItem("cart")){
    let  oldData = JSON.parse(  localStorage.getItem("cart"));
     oldData.push({
      productid,
      productName,
      productImage
     });
     localStorage.setItem("cart",JSON.stringify(oldData));
   }
   else{
     let newArray = [];
     newArray.push({
      productid,
      productName,
      productImage
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

}
