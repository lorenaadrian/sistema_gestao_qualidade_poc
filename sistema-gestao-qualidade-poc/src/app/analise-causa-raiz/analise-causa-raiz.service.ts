import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs/operators';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';

import { NaoConformidadeService } from '../nao-conformidade/nao-conformidade.service';
import { CausaRaiz } from '../Models/causa-raiz';
import { AcaoCorretiva } from '../Models/acao-corretiva';

@Injectable({
  providedIn: 'root'
})
export class AnaliseCausaRaizService {    
  constructor(private http: HttpClient,
    private router: Router,
    private serviceRNC: NaoConformidadeService) {  }

  getNCById(idNC:number){
    return this.serviceRNC.getNCById(idNC);
  }

  getListClassificacaoNC(ids: string){
    return this.serviceRNC.getListClassificacaoRNC(ids);
  }

  getTipoRequisito(id: number){
    return this.serviceRNC.getTipoRequisito(id);
  }

  getAnaliseCR(idNC: number){
    return this.http.get<CausaRaiz>(`${environment.API_URL}causaraiz/${idNC}/naoconformidade`).pipe(take(1));
  }

  getListAcaoCorretiva(idCR:number){
    return this.http.get<AcaoCorretiva[]>(`${environment.API_URL}acaocorretiva/${idCR}/causaraiz`)
  }
}
