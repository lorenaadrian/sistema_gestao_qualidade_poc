import { Component, OnInit } from '@angular/core';
import { NaoConformidade } from 'src/app/Models/nao-conformidade';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { NaoConformidadeService } from '../nao-conformidade.service';

@Component({
  selector: 'app-nao-conformidade-list',
  templateUrl: './nao-conformidade-list.component.html',
  styleUrls: ['./nao-conformidade-list.component.css']
})
export class NaoConformidadeListComponent implements OnInit {
  listaNC: Array<NaoConformidade>;  
  listaNC$: Observable<NaoConformidade[]>;

  constructor(private naoConformidadeService: NaoConformidadeService,
    private router: Router) {
  }

  ngOnInit(): void {   

      this.naoConformidadeService.listNC().subscribe(
          (rncs: NaoConformidade[]) => {this.listaNC = rncs;
        });

    }
      
    onClickEvent(id) {
      if(confirm(`Você confirma o cancelamento da Não Confirmidade ${id} ?`))
      {        
        this.naoConformidadeService.deleteNC(id).subscribe(
          succes => {
            alert("Registro cancelado com sucesso!");
            this.router.navigateByUrl('/nao-conformidade');
        },
          error => {alert("Falha ao tentar cancelar Não conformidade!")}
        )
      }

    }
}

