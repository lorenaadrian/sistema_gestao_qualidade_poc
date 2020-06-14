using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public interface ITipoRequisitoRepository : IRepositoryAsync<TipoRequisito>
    {
    
            Task<IEnumerable<TipoRequisito>> GetListByIdTipo(object id);

    }
}
