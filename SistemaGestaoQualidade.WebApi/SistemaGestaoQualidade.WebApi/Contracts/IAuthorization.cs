using NaoConformidadeModule.WebApi.Models;
using System.Threading.Tasks;

namespace NaoConformidadeModule.WebApi.Contracts
{
    public interface IAuthorization
    {
        Task<AuthorizationResult> AuthorizeAsync(IUser user);
    }
}
