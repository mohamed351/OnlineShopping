import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { FirstRegister } from '../models/firstRegister';
import jwt_decode from "jwt-decode";
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
   getName():string{
    const decoded:any = jwt_decode(localStorage.getItem("token"));
    return decoded.unique_name;
   }
   logout(){
     localStorage.removeItem("token");
   }
   login(userLoginForm){
   return  this.http.post("/api/Auth/Login",{
      phoneNumber:userLoginForm.phoneNumber,
      Password:userLoginForm.password
     }).pipe(map((tokenData)=>{
       localStorage.setItem("token",JSON.stringify(tokenData));
     }));
   }

}
