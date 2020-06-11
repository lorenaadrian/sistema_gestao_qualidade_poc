using NaoConformidadeModule.WebApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaoConformidadeModule.WebApi.Models
{
    public class TipoRequisito : IIdentityEntity
    {
        public int idTipo {get;set;}
        public string descricao { get; set; }
        public int id { get; set; }
    }
}
