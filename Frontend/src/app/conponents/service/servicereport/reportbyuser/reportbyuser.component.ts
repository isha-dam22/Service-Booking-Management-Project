import { Component, OnInit } from '@angular/core';
import { Report } from '../../Model/Report'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CanActivate, Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-reportbyuser',
  templateUrl: './reportbyuser.component.html',
  styleUrls: ['./reportbyuser.component.css']
})
export class ReportbyuserComponent implements OnInit {

  reports!: Report[];
  url = 'https://localhost:7096/api/ServiceReq/Report';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    let token = localStorage.getItem('token')
    if(token !== null){
      let jwt = JSON.parse(atob(token.split('.')[1]))
      let id = parseInt(jwt.Id)
      this.getReportByUser(id)
    }
    else{
      this.error = true
      this.message = "Token not found"
    }
    
  }

  getReportByUser(id: number) {
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
            this.reports = (<any>response).data
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
