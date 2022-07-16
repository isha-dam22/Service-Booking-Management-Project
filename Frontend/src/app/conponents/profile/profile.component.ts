import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  Password!: string

  url = 'https://localhost:7002/api/User/ChangePassword';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;
  success = false

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    console.log('ok');
    this.isSubmit = true;
    const data = {
      Password: this.Password
    };
    console.log(data);

    const credentials = JSON.stringify(data);
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
            this.success = true;
            this.message = (<any>response).message
            
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
