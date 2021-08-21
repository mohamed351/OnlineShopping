import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { EmptyLayoutComponent } from './layouts/empty-layout/empty-layout.component';
import { BaseLayoutComponent } from './layouts/base-layout/base-layout.component';




@NgModule({
  declarations: [HeaderComponent, EmptyLayoutComponent, BaseLayoutComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports:[
    HeaderComponent,
    EmptyLayoutComponent,
    BaseLayoutComponent
  ]
})
export class SharedModule { }
