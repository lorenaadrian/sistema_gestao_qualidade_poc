using SistemaGestaoQualidade.WebApi.Shared;

namespace SistemaGestaoQualidade.WebApi.Models
{
    public sealed class AuthorizationResult: BaseResult<object>
    {
        public bool IsAuthorized { get; set; }
        public string AccessToken { get; set; }
    }
}