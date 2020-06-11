import { Component } from '@angular/core';

import { RouterUser } from './Models/router-user';
import { LoginService } from './login/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [ './app.component.css' ]
})
export class AppComponent  {
  showMenuNav: boolean = false;
  listMenu: RouterUser[];
  userName: string = "";

  constructor(private serviceLogin: LoginService){  
  }

  ngOnInit(){
    this.serviceLogin.showMenuEmitter.subscribe(
      s => {
        this.showMenuNav = s
        this.userName = sessionStorage.getItem('userName');
      }
    );
    this.serviceLogin.listaMenuEmitter.subscribe(      
      l => this.listMenu = l 
    );
    
  }
  onClickEvent(){
    this.serviceLogin.logoutUser();
  }
}