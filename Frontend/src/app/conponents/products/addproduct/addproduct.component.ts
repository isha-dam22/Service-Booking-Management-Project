import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';
import { Product } from '../Model/Product'

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent implements OnInit {

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
  }

  onSubmit(){
    console.log('ok');
    this.isSubmit = true;
    const product = {
      Name: this.Name,
      Make:  this.Make,
      Model:  this.Model,
      Cost:  this.Cost,
    };
    console.log(product);

    const credentials = JSON.stringify(product);
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

}
