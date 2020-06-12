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
  numeroNC: number = 0;
  dataNC: string = "";
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
      emitenteNC: sessionStorage.getItem("userName"),
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
    if (this.numeroNC > 0){
       this.buscaNC.id = this.numeroNC;
    }
    if (this.dataNC != "") {
      this.buscaNC.dataNC = this.dataNC;
    }
    this.retornoFiltro$ = this.naoConformidadeService.getListNCByFilter(this.buscaNC);
  }
}
