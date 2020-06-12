import { Component, OnInit, Input, OnChanges, ɵɵNgOnChangesFeature } from "@angular/core";
import { NaoConformidade } from "src/app/Models/nao-conformidade";
import { Observable } from "rxjs";
import { Router } from "@angular/router";
import { NaoConformidadeService } from "../nao-conformidade.service";

@Component({
  selector: "app-nao-conformidade-list",
  templateUrl: "./nao-conformidade-list.component.html",
  styleUrls: ["./nao-conformidade-list.component.css"],
})
export class NaoConformidadeListComponent implements OnInit, OnChanges  {
  listaNC: NaoConformidade[];
  @Input() listaNC$: Observable<NaoConformidade[]>;

  constructor(
    private naoConformidadeService: NaoConformidadeService,
    private router: Router
  ) {}

  ngOnInit(): void { }

  ngOnChanges(changes){
      if(changes["listaNC$"] && this.listaNC$){
        this.listaNC$.subscribe(
          (ret:NaoConformidade[])=>{
            this.listaNC = ret;
          }
        );
      }
  }
  onClickEvent(id: any) {
    if (confirm(`Você confirma o cancelamento da Não Confirmidade ${id} ?`)) {
      this.naoConformidadeService.deleteNC(id).subscribe(
        (succes) => {
          alert("Registro cancelado com sucesso!");
          this.router.navigateByUrl("/nao-conformidade");
        },
        (error) => {
          alert("Falha ao tentar cancelar Não conformidade!");
        }
      );
    }
  }
}
