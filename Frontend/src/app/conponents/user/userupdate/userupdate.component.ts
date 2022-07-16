import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';
import { User } from '../Model/User';

@Component({
  selector: 'app-userupdate',
  templateUrl: './userupdate.component.html',
  styleUrls: ['./userupdate.component.css'],
})
export class UserupdateComponent implements OnInit {
  users!: User[];
  url = 'https://localhost:7002/api/User';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;

  name!: string;
  email!: string;
  mobile!: number;
  date!: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit(): void {
    let id = this.activatedRoute.snapshot.params['id'];
    this.getUser(id);
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

            this.name = (<any>response).data[0].Name;
            this.email = (<any>response).data[0].Email;
            this.mobile = (<any>response).data[0].Mobile;
          }
        },
        (err) => {
          this.isSubmit = false;
          this.message = 'Session Expired, You need to login';
          this.status = err.status;
        }
      );
  }

  onSubmit() {
    console.log('ok');
    this.isSubmit = true;
    const signup = {
      Id: this.activatedRoute.snapshot.params['id'],
      Name: this.name,
      Email: this.email,
      Mobile: this.mobile,
    };
    console.log(signup);

    const credentials = JSON.stringify(signup);
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
            
            this.router.navigate(['/users']);
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
