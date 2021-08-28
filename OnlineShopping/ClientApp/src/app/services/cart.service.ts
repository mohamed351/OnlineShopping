import { Injectable } from '@angular/core';
import { ProductCategory } from '../models/productCategory';

@Injectable({
  providedIn: 'root'
})
export class CartService {

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

}
