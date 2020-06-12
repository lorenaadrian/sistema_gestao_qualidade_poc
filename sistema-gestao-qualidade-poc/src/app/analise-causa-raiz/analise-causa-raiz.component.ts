import { Component, OnInit, OnDestroy, Input } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Subscription, Observable } from "rxjs";
import { NaoConformidade } from "../Models/nao-conformidade";
import { AnaliseCausaRaizService } from "./analise-causa-raiz.service";
import { ClassificacaoNaoConformidade } from "../Models/classificacao-nao-conformidade";
import { TipoRequisito } from "../Models/tipo-requisito";
import { CausaRaiz } from "../Models/causa-raiz";
import { AcaoCorretiva } from "../Models/acao-corretiva";

@Component({
  selector: "app-analise-causa-raiz",
  templateUrl: "./analise-causa-raiz.component.html",
  styleUrls: ["./analise-causa-raiz.component.css"],
})
export class AnaliseCausaRaizComponent implements OnInit, OnDestroy {
  urlImg: string = "./../../assets/SGQ_LOGO1p.png";
  @Input() id: number = 0;
  showValidation: boolean = false;
  inscricao: Subscription;
  naoConformidade: NaoConformidade;
  listaPerguntas = [
    "processo ou método",
    "material utilizado",
    "mão de obra",
    "máquina ou ferramenta",
    "medição",
    "ambiente de trabalho",
  ];
  listaResposta: Boolean[];  
  listaDescricao: String[];
  showAcaoCorretiva: boolean = false;
  listaAcaoCorretiva$: Observable<AcaoCorretiva[]>;
  total: [1, 2, 3, 4, 5, 6];
  listaClassificacaoNC$: Observable<ClassificacaoNaoConformidade[]>;
  tipoRequisito: TipoRequisito;
  causaRaiz$: Observable<CausaRaiz>;
  constructor(
    private service: AnaliseCausaRaizService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.inscricao = this.route.params.subscribe(
      (params: any) => {
      console.log(params["id"]);
      this.id = params["id"];
      if (params["id"]) {
        this.service.getNCById(params["id"]).subscribe((res: NaoConformidade) => {
          this.naoConformidade = res;
          this.service
            .getTipoRequisito(res.idTipoRequisito)
            .subscribe((resp: TipoRequisito) => {
              this.tipoRequisito = resp;
            });
          this.listaClassificacaoNC$ = this.service.getListClassificacaoNC(
            `${res.idCausaNC}
              ,${res.idEstadoNC}
              ,${res.idIdentificacaoNC}
              ,${res.idIntensidadeNC}
              ,${res.idRequisitoNC} `
          );
          this.causaRaiz$ = this.service.getAnaliseCR(res.id);
          this.causaRaiz$.subscribe((res: CausaRaiz) => {
            this.listaResposta = [res.p1, res.p2, res.p3, res.p4, res.p5, res.p6];
            this.listaDescricao = [
              res.descricaoP1,
              res.descricaoP2,
              res.descricaoP3,
              res.descricaoP4,
              res.descricaoP5,
              res.descricaoP6,
            ];
            this.listaAcaoCorretiva$ = this.service.getListAcaoCorretiva(res.id);
            this.listaAcaoCorretiva$.subscribe(
              (lac) => {
                if (lac !=null && lac.length > 0)
                this.showAcaoCorretiva = true
              }
            );
          });
        });
      }    
    });
  }
  ngOnDestroy() {
    this.inscricao.unsubscribe();
  }
  onSubmit(fCR: NgForm) {
    if (fCR.invalid) {
      this.showValidation = true;
      return;
    }
  }
}
