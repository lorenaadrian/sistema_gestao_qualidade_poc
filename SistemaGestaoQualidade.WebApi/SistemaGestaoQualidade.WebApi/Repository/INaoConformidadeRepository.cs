using NaoConformidadeModule.WebApi.Shared;
using NaoConformidadeModule.WebApi.Models;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace NaoConformidadeModule.WebApi.Repository
{
    /// <summary>
    /// Prevê o comportamento da entidade de não-conformidade do sistema
    /// </summary>
    public interface INãoConformidadeRepository : IRepositoryAsync<NaoConformidade>
    {
        Task<IEnumerable<NaoConformidade>> GetByFilter(NaoConformidade objSearch);
    }
}
