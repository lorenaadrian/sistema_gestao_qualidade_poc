using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Shared;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public interface ICausaRaizRepository : IRepositoryAsync<CausaRaiz>
    {
        Task<CausaRaiz> GetCausaRaizByNC(int idNC);
    }
}
