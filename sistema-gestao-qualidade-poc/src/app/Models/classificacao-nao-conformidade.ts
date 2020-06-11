export class ClassificacaoNaoConformidade{
    constructor(
        public descricao: string,
        public id: number,
        public tipoDominio: string,
        public textoDominio: string,
        public dominioAplicacao: string
    ){}

}