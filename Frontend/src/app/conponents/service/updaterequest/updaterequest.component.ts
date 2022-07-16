import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';

@Component({
  selector: 'app-updaterequest',
  templateUrl: './updaterequest.component.html',
  styleUrls: ['./updaterequest.component.css']
})
export class UpdaterequestComponent implements OnInit {

  url = 'https://localhost:7096/api/ServiceReq';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;

  Id!: number
    ProductId!: number
    UserId!: number
    ReqDate!: string
    Problem!: string
    Description!: string
    Status!: string

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.Id = this.activatedRoute.snapshot.params['id'];
  }

  onSubmit(){
    console.log('ok');
    this.isSubmit = true;
    const serviceReq = {
      Id: this.Id,
      ReqDate:  this.ReqDate,
      Problem:  this.Problem,
      Description:  this.Description,
      Status: this.Status
    };
    console.log(serviceReq);

    const credentials = JSON.stringify(serviceReq);
    this.http
      .put(this.url, credentials, {
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
            
            this.router.navigate(['/services/bookings']);
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
