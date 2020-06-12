import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComplianceComponent } from './compliance.component';
import { ComplianceService } from './compliance.service';

@NgModule({
  declarations: [ComplianceComponent],
  imports: [
    CommonModule
  ],
  providers:[
    ComplianceService
  ]
})
export class ComplianceModule { 
  
}
