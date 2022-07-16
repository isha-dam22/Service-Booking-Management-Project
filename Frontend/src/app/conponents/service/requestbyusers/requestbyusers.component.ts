import { Component, OnInit } from '@angular/core';
import { ServiceReq } from '../Model/ServiceReq'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CanActivate, Router } from '@angular/router';


@Component({
  selector: 'app-requestbyusers',
  templateUrl: './requestbyusers.component.html',
  styleUrls: ['./requestbyusers.component.css']
})
export class RequestbyusersComponent implements OnInit {

  serviceReqs!: ServiceReq[];
  url = 'https://localhost:7096/api/ServiceReq';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    let token = localStorage.getItem('token')
    if(token !== null){
      let jwt = JSON.parse(atob(token.split('.')[1]))
      let id = parseInt(jwt.Id)
      this.getAllServiceReqs(id)
    }
    else{
      this.error = true
      this.message = "Token not found"
    }
    
  }

  getAllServiceReqs(id:number) {
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
            this.serviceReqs = (<any>response).data;
            
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
