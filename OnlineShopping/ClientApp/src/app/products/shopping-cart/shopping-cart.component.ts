import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

import {CartService,ProductCartElements} from '../../services/cart.service';
@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
 public ProductCartElements:ProductCartElements[] |null = null;
  constructor(private cart:CartService, private product:ProductService) { }

  ngOnInit(): void {
    this.ProductCartElements = this.cart.getCartElements();
    for (const iterator of this.ProductCartElements) {
      this.product.GetProductByID(iterator.productid).subscribe(a=>{
       this.ProductCartElements =  this.ProductCartElements.map(c=>{
           if(c.productid == a.id){
             return {
               ...c,
               price: a.price
             }
           }
           else{
           return   c
           }
        });
      });

    }

  }

  calculateTotalPrice():number{
   let  number =0;
    for (const iterator of  this.ProductCartElements) {
      number += iterator.price * iterator.quantity;
    }
    return number;
  }

}
