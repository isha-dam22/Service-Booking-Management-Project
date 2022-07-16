import { Component, OnInit } from '@angular/core';
import { Report } from '../../Model/Report'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CanActivate, Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-reportdetails',
  templateUrl: './reportdetails.component.html',
  styleUrls: ['./reportdetails.component.css']
})
export class ReportdetailsComponent implements OnInit {

  reports!: Report[];
  url = 'https://localhost:7096/api/ServiceReq/Report/GetByReportId';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    let id = this.activatedRoute.snapshot.params['id'];
    this.getReport(id)
  }

  getReport(id: string) {
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
