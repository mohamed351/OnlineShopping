import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CategoryService } from '../../services/category.service';
import { Category } from 'src/app/models/category';
import { CartService } from 'src/app/services/cart.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-shopping-app',
  templateUrl: './shopping-app.component.html',
  styleUrls: ['./shopping-app.component.css']
})
export class ShoppingAppComponent implements OnInit {
 public categories:Category[] = [];
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,
    private categoryService:CategoryService ,
    public cart:CartService,
    public auth:AuthService) {}
  ngOnInit(): void {
    this.categoryService.GetCategory().subscribe(cate =>{
        this.categories = cate;
    });

  }

}
