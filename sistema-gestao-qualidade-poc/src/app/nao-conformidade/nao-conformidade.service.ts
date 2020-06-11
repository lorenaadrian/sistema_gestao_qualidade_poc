import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs/operators';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';

import { NaoConformidade } from '../Models/nao-conformidade';
import { ClassificacaoNaoConformidade } from '../Models/classificacao-nao-conformidade';
import { TipoRequisito } from '../Models/tipo-requisito';

@Injectable({
  providedIn: 'root'
})
export class NaoConformidadeService {    
  constructor(private http: HttpClient,
    private router: Router) {  }

  getClassificacaoRNC() {
    return this.http.get<ClassificacaoNaoConformidade[]>(`${environment.API_URL}classificacaonaoconformidade`).pipe(take(1));
  }
  getListClassificacaoRNC(ids: string){
    return this.http.get<ClassificacaoNaoConformidade[]>(`${environment.API_URL}classificacaonaoconformidade/${ids}`).pipe(take(1));
  }

  getListaTipoRequisito(id:number){
    return this.http.get<TipoRequisito[]>(`${environment.API_URL}processosautomotivos/listatiporequisito/${id}`).pipe(take(1));
  }

  getListClassificacaoByDominio(dominio:string){
    return this.http.get<ClassificacaoNaoConformidade[]>(`${environment.API_URL}classificacaonaoconformidade/${dominio}/dominio`)
  }

  getTipoRequisito(id:number){
    return this.http.get<TipoRequisito>(`${environment.API_URL}processosautomotivos/tiporequisito/${id}`).pipe(take(1));
  }

  getListClassificacaoByTipoDominio(tipoDominio:string){
    return this.http.get<ClassificacaoNaoConformidade[]>(`${environment.API_URL}classificacaonaoconformidade/${tipoDominio}/tipoDominio`).pipe(take(1));
  }
  createRNC(naoConformidade: NaoConformidade){
    return this.http.post<number>(`${environment.API_URL}naoconformidade`, naoConformidade).pipe(take(1));
  }
  listNC(){
    return this.http.get<NaoConformidade[]>(`${environment.API_URL}naoconformidade`).pipe(take(1));
  }
  getNCById(idNC:number){
    return this.http.get<NaoConformidade>(`${environment.API_URL}naoconformidade/${idNC}`).pipe(take(1));

  }
  setUpdateNC(naoConformidade: NaoConformidade){
    return this.http.put(`${environment.API_URL}naoconformidade`, naoConformidade).pipe(take(1));
  }
  deleteNC(id:number){
    return this.http.delete(`${environment.API_URL}naoconformidade/${id}`).pipe(take(1));
  }

  insertCR(idNC: number){
    return this.http.get(`${environment.API_URL}causaraiz/${idNC}`).pipe(take(1));
  }

  getListNCByFilter(filter:NaoConformidade){
    return this.http.post<NaoConformidade[]>(`${environment.API_URL}naoconformidade/byFilter`,filter).pipe(take(1));
  }
}
