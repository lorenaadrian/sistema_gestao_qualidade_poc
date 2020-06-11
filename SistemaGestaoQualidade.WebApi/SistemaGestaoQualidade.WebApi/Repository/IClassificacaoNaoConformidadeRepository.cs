using NaoConformidadeModule.WebApi.Models;
using NaoConformidadeModule.WebApi.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaoConformidadeModule.WebApi.Repository
{
    public interface IClassificacaoNaoConformidadeRepository : IRepositoryAsync<ClassificacaoNaoConformidade>
    {
        Task<IEnumerable<ClassificacaoNaoConformidade>> GetListByIds(string ids);
        
        Task<IEnumerable<ClassificacaoNaoConformidade>> GetListByDominio(string dominio);

        Task<IEnumerable<ClassificacaoNaoConformidade>> GetListByTipoDominio(string tipoDominio);

    }
}
