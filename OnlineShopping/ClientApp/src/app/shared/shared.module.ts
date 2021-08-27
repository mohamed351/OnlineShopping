import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { EmptyLayoutComponent } from './layouts/empty-layout/empty-layout.component';
import { BaseLayoutComponent } from './layouts/base-layout/base-layout.component';
import { ShoppingAppComponent } from './layouts/shopping-app/shopping-app.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import {HttpClientModule} from '@angular/common/http';
import {MatBadgeModule} from '@angular/material/badge';





@NgModule({
  declarations: [HeaderComponent, EmptyLayoutComponent, BaseLayoutComponent, ShoppingAppComponent ],
  imports: [
    CommonModule,
    RouterModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    HttpClientModule,
    MatBadgeModule,
  ],
  exports:[
    HeaderComponent,
    EmptyLayoutComponent,
    BaseLayoutComponent,
    ShoppingAppComponent

  ]
})
export class SharedModule { }
