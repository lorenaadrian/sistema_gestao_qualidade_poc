import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PrincipalComponent } from './principal/principal.component';
import { ComplianceComponent } from './compliance/compliance.component';
import { AuthGuard } from './guards/auth.guard';
import { ProcessosAutomotivosComponent } from './processos-automotivos/processos-automotivos.component';

const appRouter: Routes = [
  {
    path: 'nao-conformidade', loadChildren: () => import('./nao-conformidade/nao-conformidade.module')
    .then(m => m.NaoConformidadeModule)
  },
  {
    path:'analise-causa-raiz', loadChildren: () => import('./analise-causa-raiz/analise-causa-raiz.module')
    .then(m => m.AnaliseCausaRaizModule)
  },
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'principal',
    component: PrincipalComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'compliance',
    component: ComplianceComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'processos-automotivos',
    component: ProcessosAutomotivosComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(appRouter)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
