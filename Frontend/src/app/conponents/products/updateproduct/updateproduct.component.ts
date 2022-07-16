import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';

@Component({
  selector: 'app-updateproduct',
  templateUrl: './updateproduct.component.html',
  styleUrls: ['./updateproduct.component.css']
})
export class UpdateproductComponent implements OnInit {

  url = 'https://localhost:7121/api/Product';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;

  Name!: string
    Make!: string
    Model!: number
    Cost!: number

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    let id = this.activatedRoute.snapshot.params['id'];
    this.getProduct(id)
  }

  onSubmit(){
    console.log('ok');
    this.isSubmit = true;
    const signup = {
      Id: this.activatedRoute.snapshot.params['id'],
      Name: this.Name,
      Make: this.Make,
      Model: this.Model,
      Cost: this.Cost,
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
            
            this.router.navigate(['/products']);
          }
        },
        (err) => {
          this.error = true;
          this.isSubmit = false;
          this.message = err.message;
        }
      );
  }

  getProduct(id: string) {
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
            
            this.Name = (<any>response).data[0].Name
            this.Make = (<any>response).data[0].Make
            this.Model = (<any>response).data[0].Model
            this.Cost = (<any>response).data[0].Cost
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
