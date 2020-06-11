import { AuthorizationUser } from '../Models/authorization-user';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { pipe } from 'rxjs';
import { take } from 'rxjs/operators';

import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  
  urlImg: string = "assets/SGQ_LOGO1.png";
  usuario: any = {
    LoginName: '',
    Password: ''
  };

  constructor(private loginServices: LoginService,
    private router: Router) {
    sessionStorage.setItem('token', null);
  }

  onSubmit() {
    return this.loginServices.submitLogin(this.usuario);      
  }
}