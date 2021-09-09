import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { FirstRegister } from '../models/firstRegister';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }

   register(registerModel:FirstRegister){
      return   this.http.post("/api/Auth/Register",registerModel).pipe(
        map(a=>{
          localStorage.setItem("token",JSON.stringify(a));
        })
      );
   }
   isAuthicated(){
     return localStorage.getItem("token") != null ? true:false;
   }

}
