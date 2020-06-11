import { Observable } from 'rxjs';
import { OnInit, Component } from '@angular/core';

import { NaoConformidadeService } from './nao-conformidade.service';
import { NaoConformidade } from '../Models/nao-conformidade';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nao-conformidade',
  templateUrl: './nao-conformidade.component.html',
  styleUrls: ['./nao-conformidade.component.css']
})
export class NaoConformidadeComponent implements OnInit {
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
