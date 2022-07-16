import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';

@Component({
  selector: 'app-addservicereporrt',
  templateUrl: './addservicereporrt.component.html',
  styleUrls: ['./addservicereporrt.component.css']
})
export class AddservicereporrtComponent implements OnInit {

  url = 'https://localhost:7096/api/ServiceReq/Report';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;


  Id!: number
    ReportDate!: string
    ActionTaken!: string
    DiagnosisDetails!: string
    IsPaid!: string
    VisitFees!: number
    RepairDetails!: string
    SerReqId = 5
    ServiceType!: string

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    console.log('ok');
    this.isSubmit = true;
    const repoprt = {
    ReportDate: this.ReportDate,
    ActionTaken: this.ActionTaken === "yes" ? true : false,
    DiagnosisDetails: this.DiagnosisDetails,
    IsPaid: this.IsPaid === "yes" ? true : false,
    VisitFees: this.VisitFees,
    RepairDetails: this.RepairDetails,
    SerReqId: this.SerReqId,
    ServiceType: this.ServiceType,
    };
    console.log(repoprt);

    const credentials = JSON.stringify(repoprt);
    this.http
      .post(this.url, credentials, {
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
            console.log((<any>response).message);
            
            this.router.navigate(['/services/servicereports']);
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
