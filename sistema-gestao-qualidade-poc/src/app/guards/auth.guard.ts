import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';

import { LoginService } from './../login/login.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: LoginService,
    private router: Router) {

  }
  canActivate(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | boolean {
      if(this.authService.userAuthorized()){
      return true;
    } else{
      console.log("Guarda de rota: usuario não autorizado!");
      this.router.navigate(['/login']);
    }
      
  }
}
