import { Observable } from "rxjs";
import { OnInit, Component } from "@angular/core";

import { NaoConformidadeService } from "./nao-conformidade.service";
import { NaoConformidade } from "../Models/nao-conformidade";
import { Router } from "@angular/router";
import { DatePipe } from "@angular/common";

@Component({
  selector: "app-nao-conformidade",
  templateUrl: "./nao-conformidade.component.html",
  styleUrls: ["./nao-conformidade.component.css"],
})
export class NaoConformidadeComponent implements OnInit {
  numeroNC: any = 0;
  dataNC: string;
  buscaNC: NaoConformidade;
  retornoFiltro$: Observable<NaoConformidade[]>;
  constructor(
    private naoConformidadeService: NaoConformidadeService,
    private router: Router,
    private datePipie: DatePipe
  ) {}

  ngOnInit(): void {
    this.buscaNC = {
      abrangenciaNC: "",
      descricaoNC: "",
      emitenteNC: "",
      dataNC: "",
      id: 0,
      idCausaNC: 0,
      idEstadoNC: 0,
      idIdentificacaoNC: 0,
      idIntensidadeNC: 0,
      idRequisitoNC: 0,
      idTipoRequisito: 0,
      acaoImediata: "",
      dataAcaoImediata: "",
      responsavelAcaoImediata: "",
      cancelouNC: false,
      temAnaliseCR: false,
    };
  }

  onSubmit() {
    console.log(this.numeroNC);
    if(typeof this.numeroNC === undefined || this.numeroNC === null || this.numeroNC === ""){
      console.log(this.numeroNC);
      this.buscaNC.id = 0;
    } else {this.buscaNC.id = this.numeroNC;}
    if(typeof this.dataNC === undefined){
        this.buscaNC.dataNC = "";
        console.log(this.dataNC);
    } else{this.buscaNC.dataNC = this.dataNC;}
    this.retornoFiltro$ = this.naoConformidadeService.getListNCByFilter(this.buscaNC);
  }

  maskDate(data: string) {
    if (data.length == 2 || data.length == 5) {
      this.dataNC = this.dataNC + "/";
    }
  }
}
