import { Component, OnInit } from '@angular/core';
import { HttpClient,HttpHeaders  } from '@angular/common/http';
import { CanActivate, Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

    name!: string
    email!: string
    password!: string
    mobile!: number

    url = 'https://localhost:7002/api/User';
    error= false
    message!: string
    isSubmit = false

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    console.log("ok");
    this.isSubmit = true
    const signup = {
      name: this.name,
      email: this.email,
      password: this.password,
      mobile: this.mobile
    }
    console.log(signup);
    
    const credentials = JSON.stringify(signup);
    this.http.post(this.url, credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      const error = (<any>response).error;
      if(error)
      {
        this.error = true;
        this.isSubmit = false
        this.message = (<any>response).message
      }
      else{
        this.error = false;
      // this.toastr.success("Logged In successfully");
      this.isSubmit = false
      this.router.navigate(["/signin"]);
      }
      
    }, err => {
      this.error = true;
      this.isSubmit = false
      this.message = err.message
    });

  }

}
