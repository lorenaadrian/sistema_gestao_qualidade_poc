using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using NaoConformidadeModule.WebApi.Contracts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NaoConformidadeModule.WebApi.Repository
{
    public sealed class AuthorizationCore : Contracts.IAuthorization
    {
        public async Task<Models.AuthorizationResult> AuthorizeAsync(IUser user)
        {
            //Aqui aplicaríamos regras específicas para autorização
            Models.AuthorizationResult result = new Models.AuthorizationResult();
            result.IsAuthorized = true;
            result.IsValid = true;
            result.DataEntity = user; //O tipo de usuário informado trás as regras de acesso
            result.Message = "User Authorized";
            result.AccessToken = GetAccessToken(user); //Gero token baseado nos dados de usuário
            return await Task.FromResult(result);
        }

        private string GetAccessToken(IUser user)
        {
            byte[] symmetricKey = Convert.FromBase64String("4Bms3ZBc9GpI18k3yJR54Fcdj9IjP8iyKy3wTKsh+l5caz1OESmINdnYJw2Onf5fVouHSWKqs8EAsxa6jdUH0Q==");
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, user.UserName.ToString()),
                            new Claim(ClaimTypes.Role, user.UserRole.ToString())
                        }),
                Issuer = "POCLACC",
                Audience = "SGC_POC",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow + TimeSpan.FromSeconds(60000)
            });

            return handler.WriteToken(securityToken);
        }
    }
}
