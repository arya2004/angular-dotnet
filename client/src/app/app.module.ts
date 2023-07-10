import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from "@angular/common/http"

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';

import { PaginationModule } from 'ngx-bootstrap/pagination';
import { HomeModule } from './home/home.module';

@NgModule({
  declarations: [
    AppComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
   
    PaginationModule.forRoot(),
    HomeModule
  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
