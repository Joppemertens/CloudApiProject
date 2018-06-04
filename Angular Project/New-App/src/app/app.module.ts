import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import {RouterModule} from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import {FormsModule} from '@angular/forms';
import { DelijnComponent } from './delijn/delijn.component';
import { DeLijnService } from './services/delijn.service';


@NgModule({
  declarations: [
    AppComponent,
    DelijnComponent
  ],
  imports: [
    MDBBootstrapModule.forRoot(),
    BrowserModule,
    RouterModule.forRoot([

    ],{useHash:true}),
    FormsModule,
    HttpClientModule
  ],
  providers: [
    DeLijnService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
