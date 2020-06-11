using NaoConformidadeModule.WebApi.Models;
using NaoConformidadeModule.WebApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaoConformidadeModule.WebApi.Repository
{
    public interface IAcaoCorretivaRepository : IRepositoryAsync<AcaoCorretiva>
    {
        Task<IEnumerable<AcaoCorretiva>> GetAcaoByCR(int idNC);
    }
}
