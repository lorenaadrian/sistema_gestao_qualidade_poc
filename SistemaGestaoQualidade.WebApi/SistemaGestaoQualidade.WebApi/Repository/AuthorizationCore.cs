using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SistemaGestaoQualidade.WebApi.Contracts;

namespace SistemaGestaoQualidade.WebApi.Repository
{
    public sealed class AuthorizationCore : IAuthorizationCore
    {
        private readonly string Secret = "4Bms3ZBc9GpI18k3yJR54Fcdj9IjP8iyKy3wTKsh+l5caz1OESmINdnYJw2Onf5fVouHSWKqs8EAsxa6jdUH0Q==";
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
            try
            {
                var securityKey = Encoding.ASCII.GetBytes(Secret);
                var subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole.ToString())
                        });
                var expires = DateTime.UtcNow.AddHours(2);
                var signingCredential = new SigningCredentials(
                        new SymmetricSecurityKey(securityKey),
                        SecurityAlgorithms.HmacSha256Signature);
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    SigningCredentials = signingCredential
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
