import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private auth:AuthService, private router:Router) { }
  form:FormGroup = new FormGroup({
    phone:new FormControl("",[Validators.required ]),
    address:new FormControl("",[Validators.required]),
    password:new FormControl("",[Validators.required]),
    email:new FormControl("",[Validators.required, Validators.email]),
    userName:new FormControl("",[Validators.required])
  })
  ngOnInit(): void {


  }
  register(){

    console.log(this.form.value);
    this.auth.register(this.form.value).subscribe(result => {
      this.router.navigate(["/products"]);
    });
  }

}
