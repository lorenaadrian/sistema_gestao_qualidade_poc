import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';
import { AnaliseCausaRaizComponent } from './analise-causa-raiz.component';

const analiseCausaRaizRouter: Routes = [
  { path: ':id', component: AnaliseCausaRaizComponent, canActivate: [AuthGuard]
  }
  //{ path: 'novo', component: NaoConformidadeDetailComponent, canActivate: [AuthGuard]},
  //{ path: ':id', component: NaoConformidadeDetailComponent, canActivate: [AuthGuard]}
  
];

@NgModule({
  imports: [RouterModule.forChild(analiseCausaRaizRouter)],
  exports: [RouterModule],
})
export class AnaliseCausaRaizRoutingModule {}
