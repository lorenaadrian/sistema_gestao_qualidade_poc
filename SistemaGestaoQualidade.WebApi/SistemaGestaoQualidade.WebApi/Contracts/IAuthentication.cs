using NaoConformidadeModule.WebApi.Models;
using System.Threading.Tasks;

namespace NaoConformidadeModule.WebApi.Contracts
{
    public interface IAuthentication
    {
        Task<BaseResult<IUser>> AuthenticateAsync(LoginCredencials loginUser);
    }
}
