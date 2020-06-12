
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginModule } from './login/login.module';
import { PrincipalModule } from './principal/principal.module';
import { LoginService } from './login/login.service';
import { RequestInterceptorModule } from './request-interceptor/request-interceptor.module';
import { AuthGuard } from './guards/auth.guard';
import { AppRoutingModule } from './app.routing.module';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    BrowserModule,
    LoginModule,
    PrincipalModule,
    RequestInterceptorModule,
    HttpClientModule,
    AppRoutingModule
  ],
  declarations: [
    AppComponent
  ],
  providers:[
    LoginService,
    AuthGuard
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }


/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/