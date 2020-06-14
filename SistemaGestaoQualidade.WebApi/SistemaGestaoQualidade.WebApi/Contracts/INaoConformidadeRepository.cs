using SistemaGestaoQualidade.WebApi.Shared;
using SistemaGestaoQualidade.WebApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    /// <summary>
    /// Prevê o comportamento da entidade de não-conformidade do sistema
    /// </summary>
    public interface INãoConformidadeRepository : IRepositoryAsync<NaoConformidade>
    {
        Task<IEnumerable<NaoConformidade>> GetByFilter(NaoConformidade objSearch);
    }
}
