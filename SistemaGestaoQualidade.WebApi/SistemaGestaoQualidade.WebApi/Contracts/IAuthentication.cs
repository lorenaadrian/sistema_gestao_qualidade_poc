using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Shared;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public interface IAuthentication
    {
        Task<BaseResult<IUser>> AuthenticateAsync(LoginCredencials loginUser);
    }
}
