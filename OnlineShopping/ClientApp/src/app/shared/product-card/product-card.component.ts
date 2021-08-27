import { Component, Input, OnInit, Output , EventEmitter } from '@angular/core';

import { Products } from 'src/app/models/product';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.css']
})
export class ProductCardComponent implements OnInit {
  @Input("product") simpleInfo:Products;
  @Output("clickDetails") detailsClicked:EventEmitter<any> = new EventEmitter<any>();
  constructor() { }

  ngOnInit() {
  }

  clickDetails(){
    this.detailsClicked.emit(this.simpleInfo);
  }

}
