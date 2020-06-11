namespace NaoConformidadeModule.WebApi.Models
{
    public sealed class AuthorizationResult: BaseResult<object>
    {
        public bool IsAuthorized { get; set; }
        public string AccessToken { get; set; }
    }
}