using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Shared;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public sealed class AuthenticationCore : IAuthentication
    {
        public async Task<BaseResult<IUser>> AuthenticateAsync(LoginCredencials loginUser)
        {
            var result = new BaseResult<IUser>();
            result.IsValid = false;
            result.Message = "User Unauthenticated";
            if (!(string.IsNullOrEmpty(loginUser.LoginName) || string.IsNullOrEmpty(loginUser.Password)))
            {
                if (loginUser.Password == "teste1234") //Valido se é uma senha válida
                {
                    result.DataEntity = new UserModel().GetUser(loginUser.LoginName); //Recupero os dados do usuário informado
                    result.IsValid = !(result.DataEntity == null); //Valido se existe o usuário informado baseada na recuperação dos seus dados
                    result.Message = "User authenticated"; //Retorno que está autenticado
                }
            }
            return await Task.FromResult(result);
        }


    }
}