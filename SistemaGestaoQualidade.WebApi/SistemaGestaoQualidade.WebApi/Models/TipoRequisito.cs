using SistemaGestaoQualidade.WebApi.Shared;

namespace SistemaGestaoQualidade.WebApi.Models
{
    public class TipoRequisito : IIdentityEntity
    {
        public int idTipo {get;set;}
        public string descricao { get; set; }
        public int id { get; set; }
    }
}
