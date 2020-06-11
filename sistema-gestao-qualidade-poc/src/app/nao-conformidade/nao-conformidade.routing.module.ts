import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NaoConformidadeComponent } from './nao-conformidade.component';
import { NaoConformidadeDetailComponent } from "./nao-conformidade-detail/NaoConformidadeDetailComponent";
import { AuthGuard } from '../guards/auth.guard';
import { NaoConformidadeListComponent } from './nao-conformidade-list/nao-conformidade-list.component';

const naoConformidadeRouter: Routes = [
  { path: '', component: NaoConformidadeComponent, canActivate: [AuthGuard]},
  { path: 'novo', component: NaoConformidadeDetailComponent, canActivate: [AuthGuard]},
  { path: 'list', component:NaoConformidadeListComponent, canActivate:[AuthGuard]} ,
  { path: ':id', component: NaoConformidadeDetailComponent, canActivate: [AuthGuard]} ,
  
];

@NgModule({
  imports: [RouterModule.forChild(naoConformidadeRouter)],
  exports: [RouterModule],
})
export class NaoConformidadeRoutingModule {}
