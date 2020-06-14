import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {  take } from 'rxjs/operators';

import { AuthorizationUser } from '../Models/authorization-user';
import { Router } from '@angular/router';
import { RouterUser } from '../Models/router-user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  showMenuEmitter = new EventEmitter<boolean>();
  listaMenuEmitter = new EventEmitter<RouterUser[]>();
  private isAutorized: boolean = false;
  
  constructor(private http: HttpClient,
    private router: Router) {  }

  submitLogin(usuario: any) {
    this.http.post<AuthorizationUser>(`${environment.API_URL}login`, usuario)
      .pipe(take(1))
      .subscribe(
        (res: AuthorizationUser) => {
          sessionStorage.setItem('accessToken', res.accessToken);
          sessionStorage.setItem('isAuthorized', res.isAuthorized);
          sessionStorage.setItem('userName', res.dataEntity.userName);
          sessionStorage.setItem('userCredencial', res.dataEntity.userCredencial);
          
          if (res.isAuthorized){
            this.isAutorized = true;
            this.showMenuEmitter.emit(true); 
            this.listaMenuEmitter.emit(res.dataEntity.userRole);
            this.router.navigateByUrl('/principal');
          }
          else{
            this.isAutorized = false;
            this.showMenuEmitter.emit(false);
          }
        }
      );
  }

  userAuthorized(): boolean{
    return this.isAutorized;
  }

  logoutUser(){
    sessionStorage.setItem('accessToken', null);
    sessionStorage.setItem('isAuthorized', null);
    sessionStorage.setItem('userName', null);
    this.isAutorized = false;
    this.showMenuEmitter.emit(false);
    this.router.navigateByUrl('/login');
  }
}
