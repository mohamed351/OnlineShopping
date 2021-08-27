import { Component, OnInit, VERSION } from '@angular/core';
import { ActivatedRoute, Data, Router } from '@angular/router';
import { ProductCategory } from 'src/app/models/productCategory';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-product-category',
  templateUrl: './product-category.component.html',
  styleUrls: ['./product-category.component.css']
})
export class ProductCategoryComponent implements OnInit {
public  productCategory:ProductCategory[] = [];

  constructor(private router:ActivatedRoute, public cart:CartService) { }

  ngOnInit(): void {
    this.router.data.subscribe((data:Data)=>{
        this.productCategory = data["data"];
        console.log(this.productCategory);
    });

  }

  addCart(productNumber:number, productName:string,productImage:string){
    this.cart.addProductCart(productNumber,productName,productImage);
  }


}
