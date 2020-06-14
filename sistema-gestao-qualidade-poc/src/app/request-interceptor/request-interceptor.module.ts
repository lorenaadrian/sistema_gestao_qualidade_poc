import { LoginService } from './../login/login.service';
import { Observable } from 'rxjs';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HTTP_INTERCEPTORS
} from '@angular/common/http';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: RequestInterceptorModule,
      multi: true,
    },]
})
//@Injectable()

export class RequestInterceptorModule implements HttpInterceptor {
  private token: string;
  constructor(public serviceAuth: LoginService) {
    this.token = sessionStorage.getItem('accessToken');
  }
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler, ): Observable<HttpEvent<any>> {
    if (this.token != null) {
      const cloneReq = req.clone({
        setHeaders: {
          //'Content-Type': 'application/json; charset=utf-8'
          'Authorization': `Bearer ${this.token}`
        }
      });
      return next.handle(cloneReq);
    }
    else {
      return next.handle(req);
    }
  }
}
