import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AnaliseCausaRaizComponent } from './analise-causa-raiz.component';
import { AnaliseCausaRaizRoutingModule } from './analise-causa-raiz.routing.module';
import { AnaliseCausaRaizService } from './analise-causa-raiz.service';
import { NaoConformidadeService } from '../nao-conformidade/nao-conformidade.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    AnaliseCausaRaizRoutingModule],
  exports: [],
  declarations: [AnaliseCausaRaizComponent],
  providers: [
    AnaliseCausaRaizService,
    NaoConformidadeService
  ],
})
export class AnaliseCausaRaizModule {}
