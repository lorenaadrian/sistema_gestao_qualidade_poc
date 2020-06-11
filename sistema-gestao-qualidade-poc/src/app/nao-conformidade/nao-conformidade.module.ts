import { NgModule } from "@angular/core";
import { CommonModule, DatePipe } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { NaoConformidadeRoutingModule } from "./nao-conformidade.routing.module";
import { NaoConformidadeComponent } from "./nao-conformidade.component";
import { NaoConformidadeDetailComponent } from "./nao-conformidade-detail/NaoConformidadeDetailComponent";
import { NaoConformidadeService } from "./nao-conformidade.service";
import { NaoConformidadeListComponent } from './nao-conformidade-list/nao-conformidade-list.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NaoConformidadeRoutingModule,
  ],
  exports: [],
  declarations: [
    NaoConformidadeComponent, 
    NaoConformidadeDetailComponent, 
    NaoConformidadeListComponent
  ],
  providers: [
    NaoConformidadeService, 
    DatePipe],
})
export class NaoConformidadeModule {}
