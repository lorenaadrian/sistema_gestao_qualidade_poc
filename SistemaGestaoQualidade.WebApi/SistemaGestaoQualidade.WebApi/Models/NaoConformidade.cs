using NaoConformidadeModule.WebApi.Shared;
using System;

namespace NaoConformidadeModule.WebApi.Models
{
    public class NaoConformidade : IIdentityEntity
    {
        public int id { get; set; }
        public string dataNC { get; set; }
        public string emitenteNC { get; set; }
        public int idCausaNC { get; set; }
        public int idEstadoNC { get; set; }
        public int idIdentificacaoNC {get;set;}
        public int idIntensidadeNC { get; set; }
        public int idRequisitoNC { get; set; }
        public int idTipoRequisito { get; set; }
        public string descricaoNC { get; set; }
        public string abrangenciaNC { get; set; }        
        public string acaoImediata { get; set; }        
        public string dataAcaoImediata { get; set; }
        public string responsavelAcaoImediata { get; set; }
        public Boolean temAnaliseCR { get; set; }
        public Boolean cancelouNC { get; set; }
    }
}
