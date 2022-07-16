import { Component, OnInit } from '@angular/core';
import { HttpClient,HttpHeaders  } from '@angular/common/http';
import { CanActivate, Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

    email!: string
    password!: string

    url = 'https://localhost:7184/api/Login';
    error= false
    message!: string
    isSubmit = false

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    console.log("ok");
    this.isSubmit = true
    const signin = {
      email: this.email,
      password: this.password
    }
    console.log(signin);

    const credentials = JSON.stringify(signin);
    this.http.post(this.url, credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      const error = (<any>response).error;
      if(error)
      {
        this.error = true;
        this.message = (<any>response).message
        this.isSubmit = false
      }
      else{
        const token = (<any>response).token;
        localStorage.setItem("token", token);
        this.error = false;
        this.isSubmit = false
        this.router.navigate(["/users"]);
      }
      
    }, err => {
      this.error = true;
      this.isSubmit = false
      this.message = err.message
    });
  }

}
