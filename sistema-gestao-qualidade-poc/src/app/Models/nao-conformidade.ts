export class NaoConformidade{
          constructor(
            public id: number,
            public dataNC: string,
            public emitenteNC: string,
            public idCausaNC: number,
            public idEstadoNC: number,
            public idIdentificacaoNC: number,
            public idIntensidadeNC: number,
            public idRequisitoNC: number,
            public idTipoRequisito: number,
            public descricaoNC: string,
            public abrangenciaNC: string,
            public acaoImediata: string,
            public dataAcaoImediata: string,
            public responsavelAcaoImediata: string,
            public temAnaliseCR: boolean,
            public cancelouNC: boolean
          ){}
      
      }