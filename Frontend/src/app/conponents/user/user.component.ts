import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CanActivate, Router } from '@angular/router';
import { User } from './Model/User';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  
  users!: [];
  url = 'https://localhost:7002/api/User';
  error = false;
  message!: string;
  isSubmit = false;

  constructor(private http: HttpClient, private router: Router) {}

  ngOnInit() {
    this.getAllUsers()
  }

  getAllUsers() {
    this.isSubmit = true;
    this.http
      .get(this.url, {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
          Authorization: 'Bearer ' + localStorage.getItem('token'),
        }),
      })
      .subscribe(
        (response) => {
          const error = (<any>response).error;
          if (error) {
            this.error = true;
            this.isSubmit = false;
            this.message = (<any>response).message;
          } else {
            this.error = false;
            // this.toastr.success("Logged In successfully");
            this.isSubmit = false;
            this.users = (<any>response).data;
            
          }
        },
        (err) => {
          this.error = true;
          this.isSubmit = false;
          this.message = err.message;
        }
      );
  }
}
