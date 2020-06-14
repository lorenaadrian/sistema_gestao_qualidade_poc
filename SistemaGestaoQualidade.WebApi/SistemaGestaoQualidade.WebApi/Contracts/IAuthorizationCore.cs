using SistemaGestaoQualidade.WebApi.Models;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public interface IAuthorizationCore
    {
        Task<AuthorizationResult> AuthorizeAsync(IUser user);
    }
}
