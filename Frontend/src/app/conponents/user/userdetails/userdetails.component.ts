import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';
import { User } from '../Model/User'
import {formatDate } from '@angular/common';

@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent implements OnInit {

  users!: User[];
  url = 'https://localhost:7002/api/User';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;

  
  name!: string
  email!: string
  mobile!: number
  date!: string

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    let id = this.activatedRoute.snapshot.params['id'];
    this.getUser(id)
  }
 
  getUser(id: string) {
    this.isSubmit = true;
    this.http
      .get(`${this.url}/${id}`, {
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
            
            this.name = (<any>response).data[0].Name
            this.email = (<any>response).data[0].Email
            this.mobile = (<any>response).data[0].Mobile
            this.date = formatDate((<any>response).data[0].Registrationdate, 'yyyy-MM-dd', 'en-US');
          }
        },
        (err) => {
          this.isSubmit = false;
          this.message = "Session Expired, You need to login";
          this.status = err.status
        }
      );
  }

}
