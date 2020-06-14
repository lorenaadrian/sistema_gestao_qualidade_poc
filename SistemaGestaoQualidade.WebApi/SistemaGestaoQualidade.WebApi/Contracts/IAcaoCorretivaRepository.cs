using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public interface IAcaoCorretivaRepository : IRepositoryAsync<AcaoCorretiva>
    {
        Task<IEnumerable<AcaoCorretiva>> GetAcaoByCR(int idNC);
    }
}
