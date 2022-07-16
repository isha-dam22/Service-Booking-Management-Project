import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SigninComponent } from './conponents/signin/signin.component';
import { NavbarComponent } from './conponents/navbar/navbar.component';
import { SignupComponent } from './conponents/signup/signup.component';
import { UserComponent } from './conponents/user/user.component';
import { UserlistComponent } from './conponents/user/userlist/userlist.component';
import { UserdetailsComponent } from './conponents/user/userdetails/userdetails.component';
import { UserupdateComponent } from './conponents/user/userupdate/userupdate.component';
import { ServiceComponent } from './conponents/service/service.component';
import { BookingComponent } from './conponents/service/booking/booking.component';
import { ProductsComponent } from './conponents/products/products.component';
import { ProductlistComponent } from './conponents/products/productlist/productlist.component';
import { AddproductComponent } from './conponents/products/addproduct/addproduct.component';
import { UpdateproductComponent } from './conponents/products/updateproduct/updateproduct.component';
import { ProductdetailsComponent } from './conponents/products/productdetails/productdetails.component';
import { BookserviceComponent } from './conponents/service/bookservice/bookservice.component';
import { ServicereportComponent } from './conponents/service/servicereport/servicereport.component';
import { ServicereporlistComponent } from './conponents/service/servicereport/servicereporlist/servicereporlist.component';
import { AddservicereporrtComponent } from './conponents/service/servicereport/addservicereporrt/addservicereporrt.component';
import { ProfileComponent } from './conponents/profile/profile.component';
import { UpdaterequestComponent } from './conponents/service/updaterequest/updaterequest.component';
import { RequestbyusersComponent } from './conponents/service/requestbyusers/requestbyusers.component';
import { ReportdetailsComponent } from './conponents/service/servicereport/reportdetails/reportdetails.component';
import { ReportbyuserComponent } from './conponents/service/servicereport/reportbyuser/reportbyuser.component';

@NgModule({
  declarations: [
    AppComponent,
    SigninComponent,
    NavbarComponent,
    SignupComponent,
    UserComponent,
    UserlistComponent,
    UserdetailsComponent,
    UserupdateComponent,
    ServiceComponent,
    BookingComponent,
    ProductsComponent,
    ProductlistComponent,
    AddproductComponent,
    UpdateproductComponent,
    ProductdetailsComponent,
    BookserviceComponent,
    ServicereportComponent,
    ServicereporlistComponent,
    AddservicereporrtComponent,
    ProfileComponent,
    UpdaterequestComponent,
    RequestbyusersComponent,
    ReportdetailsComponent,
    ReportbyuserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
