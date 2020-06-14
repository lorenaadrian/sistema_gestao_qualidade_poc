using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public interface IClassificacaoNaoConformidadeRepository : IRepositoryAsync<ClassificacaoNaoConformidade>
    {
        Task<IEnumerable<ClassificacaoNaoConformidade>> GetListByIds(string ids);
        
        Task<IEnumerable<ClassificacaoNaoConformidade>> GetListByDominio(string dominio);

        Task<IEnumerable<ClassificacaoNaoConformidade>> GetListByTipoDominio(string tipoDominio);

    }
}
