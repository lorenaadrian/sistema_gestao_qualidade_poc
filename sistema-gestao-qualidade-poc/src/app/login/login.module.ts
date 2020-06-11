import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginComponent } from './login.component';
import { LoginService } from './login.service';

@NgModule({
  declarations: [
      LoginComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  providers:[
      LoginService
  ],
  exports:[
      LoginComponent
  ]
})
export class LoginModule { }