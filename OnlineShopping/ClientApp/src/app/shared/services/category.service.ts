import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from 'src/app/models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) {

   }

   GetCategory(){
    return this.http.get<Category[]>("/api/Categories");
   }
}
