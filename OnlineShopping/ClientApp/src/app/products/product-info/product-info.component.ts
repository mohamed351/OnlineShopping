import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SingleProduct } from 'src/app/models/singleProduct';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-info',
  templateUrl: './product-info.component.html',
  styleUrls: ['./product-info.component.css']
})
export class ProductInfoComponent implements OnInit {
  public singleProduct:SingleProduct = null;
  constructor(private productService:ProductService, private ActiveRouter:ActivatedRoute, public cart:CartService) { }

  ngOnInit(): void {
      this.singleProduct.productName
    this.ActiveRouter.params.subscribe(data=>{
      this.productService.GetProductByID(data["id"]).subscribe(singleProduct =>{
        this.singleProduct = singleProduct;
      });
    });

  }
  addCart(productNumber:number, productName:string,productImage:string){

    this.cart.addProductCart(productNumber,productName,productImage);
  }

}
