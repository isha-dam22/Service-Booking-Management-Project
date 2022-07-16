import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, CanActivate, Router } from '@angular/router';
import {formatDate } from '@angular/common';

@Component({
  selector: 'app-productdetails',
  templateUrl: './productdetails.component.html',
  styleUrls: ['./productdetails.component.css']
})
export class ProductdetailsComponent implements OnInit {

  url = 'https://localhost:7121/api/Product';
  error = false;
  message!: string;
  isSubmit = false;
  status!: null;

    Id!: number
    Name!: string
    Make!: string
    Model!: number
    Cost!: number
    CreatedDate!: string

  constructor(private activatedRoute: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    let id = this.activatedRoute.snapshot.params['id'];
    this.getProduct(id)
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
            this.CreatedDate = formatDate((<any>response).data[0].CreatedDate, 'yyyy-MM-dd', 'en-US');
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
