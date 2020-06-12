import { Component, OnInit, OnDestroy } from "@angular/core";
import { Subscription, Observable } from "rxjs";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { DatePipe } from "@angular/common";
import { ClassificacaoNaoConformidade } from "../../Models/classificacao-nao-conformidade";
import { NaoConformidade } from "../../Models/nao-conformidade";
import { NaoConformidadeService } from "../nao-conformidade.service";
import { TipoRequisito } from "src/app/Models/tipo-requisito";
import { calcPossibleSecurityContexts } from "@angular/compiler/src/template_parser/binding_parser";
@Component({
  selector: "app-nao-conformidade-detail",
  templateUrl: "./nao-conformidade-detail.component.html",
  styleUrls: ["./nao-conformidade-detail.component.css"],
})
export class NaoConformidadeDetailComponent implements OnInit, OnDestroy {
  urlImg: string = "./../../assets/SGQ_LOGO1p.png";
  id: number;
  inscricao: Subscription;
  isReadOnly: boolean = true;
  showValidation: boolean = false;
  showClassificacao: boolean = false;
  showInputValidation: boolean = false;
  listaCausaNC = new Array<ClassificacaoNaoConformidade>();
  listaEstadoNC = new Array<ClassificacaoNaoConformidade>();
  listaIntensidadeNC = new Array<ClassificacaoNaoConformidade>();
  listaIdentificacaoNC = new Array<ClassificacaoNaoConformidade>();
  listaRequisitoNC = new Array<ClassificacaoNaoConformidade>();
  listaTipoRequisitoNC$: Observable<TipoRequisito[]>;
  listaClassificacaoNC$: Observable<ClassificacaoNaoConformidade[]>;
  tipoRequisito: TipoRequisito;
  fRNC: NaoConformidade;
  constructor(
    private naoConformidadeService: NaoConformidadeService,
    private route: ActivatedRoute,
    private datePipie: DatePipe,
    private router: Router
  ) { }
  ngOnInit(): void {
    this.inscricao = this.route.paramMap.subscribe(params => {
      this.id = Number.parseInt(params.get('id'));
    });
    if (this.id > 0) {
      this.showClassificacao = false;
      this.naoConformidadeService.getNCById(this.id).subscribe(
        (res: NaoConformidade) => {
          this.fRNC = res;
          this.naoConformidadeService
            .getTipoRequisito(res.idTipoRequisito)
            .subscribe((resp: TipoRequisito) => {
              this.tipoRequisito = resp;
            });
          this.listaClassificacaoNC$ = this.naoConformidadeService
            .getListClassificacaoRNC(`${res.idCausaNC},
            ${res.idEstadoNC}, ${res.idIdentificacaoNC},${res.idIntensidadeNC},
            ${res.idRequisitoNC}`);
        },
        (err) => {
          console.log(err);
        }
      );
    } else {
      this.isReadOnly = false;
      this.showClassificacao = true;
      this.listaClassificacaoNC$ = this.naoConformidadeService.getListClassificacaoByDominio(
        "NaoConformidade"
      );
      this.listaClassificacaoNC$.subscribe(
        (res: ClassificacaoNaoConformidade[]) => {
          res.forEach((element) => {
            this.naoConformidadeService
              .getListClassificacaoByTipoDominio(element.tipoDominio)
              .subscribe((resp: ClassificacaoNaoConformidade[]) => {
                switch (element.tipoDominio) {
                  case "Intensidade":
                    this.listaIntensidadeNC = resp;
                    break;
                  case "Identificação":
                    this.listaCausaNC = resp;
                    break;
                  case "Estado":
                    this.listaEstadoNC = resp;
                    break;
                  case "Causa":
                    this.listaIdentificacaoNC = resp;
                    break;
                  case "Requisito":
                    this.listaRequisitoNC = resp;
                    break;
                }
              });
          });
        }
      );
      this.fRNC = {
        abrangenciaNC: "",
        descricaoNC: "",
        emitenteNC: sessionStorage.getItem("userName"),
        dataNC: this.datePipie.transform(Date.now(), "dd/MM/yyyy"),
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
  }

  onSubmit(f: NgForm) {
    this.showInputValidation = this.fRNC.idCausaNC === 0
      || this.fRNC.idEstadoNC === 0
      || this.fRNC.idIdentificacaoNC === 0
      || this.fRNC.idIntensidadeNC === 0
      || this.fRNC.idRequisitoNC === 0
      || this.fRNC.idTipoRequisito === 0;
    if (f.invalid || this.showInputValidation) {
      this.showValidation = true;
      return;
    } else {
      this.showValidation = false;
      if (this.fRNC.id > 0) {
        this.naoConformidadeService.setUpdateNC(this.fRNC).subscribe(
          (success) => {
            alert("Atualização realizada com sucesso!");
          },
          (error) => alert("Falha ao tentar atualizar não conformidade!")
        );
        this.router.navigateByUrl("/principal");
      } else {
        this.naoConformidadeService.createRNC(this.fRNC).subscribe(
          (success: number) => {
            if (this.fRNC.temAnaliseCR) {
              this.naoConformidadeService.insertCR(success).subscribe();
            }
            alert(
              `Registro de Não Conformidade número ${success} cadastrado com sucesso!`
            );
            this.router.navigateByUrl("/principal");
          },
          (error) => {
            return alert("Falha ao tentar registrar não conformidade!");
          }
        );
      }
    }
  }
  ngOnDestroy() {
    this.inscricao.unsubscribe();
  }
  maskDate(dataAcaoImediata: string) {
    if (dataAcaoImediata.length == 2 || dataAcaoImediata.length == 5) {
      this.fRNC.dataAcaoImediata = this.fRNC.dataAcaoImediata + "/";
    }
  }
  buscaTipo() {
    this.fRNC.idTipoRequisito = 0;
    this.showInputValidation = false;
    this.showValidation = false;
    this.listaTipoRequisitoNC$ = this.naoConformidadeService.getListaTipoRequisito(
      this.fRNC.idRequisitoNC
    );
  }
  tipoSelect(id) {
    this.fRNC.idTipoRequisito = id;
    this.showInputValidation = false;
  }
}
