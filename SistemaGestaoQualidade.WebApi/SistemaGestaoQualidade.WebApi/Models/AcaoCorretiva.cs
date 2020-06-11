using NaoConformidadeModule.WebApi.Shared;

namespace NaoConformidadeModule.WebApi.Models
{
    public class AcaoCorretiva : IIdentityEntity
    {
        public int id { get; set; }
        public int idCR { get; set; }
        public string acaoCorretiva {get;set;}
        public string riscoOportunidade { get; set; }
        public string dataAcaoCorretiva { get; set; }
        public string responsavel { get; set; }


    }
}
