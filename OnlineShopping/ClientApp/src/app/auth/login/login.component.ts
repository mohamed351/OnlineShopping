import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form:FormGroup = new FormGroup({
    phoneNumber:new FormControl("",[Validators.required]),
    password:new FormControl("",[Validators.required])
  });
  constructor(public authService:AuthService, private router:Router) { }

  ngOnInit(): void {
  }
  loginUser(){
    this.authService.login(this.form.value).subscribe(result =>{
      this.router.navigate(["/products"]);
    });
  }

}
