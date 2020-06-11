export class AcaoCorretiva {
  constructor(
    public id: number,
    public idCR: number,
    public acaoCorretiva: string,
    public riscoOportunidade: string,
    public dataAcaoCorretiva: string,
    public responsavel: string
  ) {}
}
