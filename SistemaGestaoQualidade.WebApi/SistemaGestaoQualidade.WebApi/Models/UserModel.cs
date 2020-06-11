using NaoConformidadeModule.WebApi.Contracts;
using System.Collections.Generic;

namespace NaoConformidadeModule.WebApi.Models
{
    public class UserModel : IUser
    {
        private List<UserModel> fakeUserBase;
        public string UserName { get; set; }
        public IRoutersUser[] UserRole { get; set; }
        public string UserCredencial { get; set; }

        public UserModel GetUser(string userCredencial)
        {
            if (fakeUserBase == null)
            {
                SetFakeBdUsers();
            }
            return fakeUserBase.Find(x => x.UserCredencial == userCredencial);
        }

        public void SetFakeBdUsers()
        {
            fakeUserBase = new List<UserModel>();
            fakeUserBase.Add(new UserModel
            {
                UserName = "Fabiano Garcia", //Diretor de Qualidade
                UserCredencial = "M0001",
                UserRole = new RouterUserModel[]
                {
                    new RouterUserModel{RouterLink = "nao-conformidade", TextRouter = "Não Conformidade", IsImplements = true},
                    new RouterUserModel{RouterLink = "processos-automotivos", TextRouter = "Processos Automotivos", IsImplements = false},
                    new RouterUserModel{RouterLink = "compliance", TextRouter = "Compliance", IsImplements = true },
                    new RouterUserModel{RouterLink = "relatorios-gerenciais", TextRouter = "Relatórios Gerenciais", IsImplements = false },
                    new RouterUserModel{RouterLink = "inteligencia-negocio", TextRouter = "Inteligência de Negócio", IsImplements = false },
                    new RouterUserModel{RouterLink = "divulgacao-transparencia", TextRouter = "Divulgação e Transparência", IsImplements = false }
                }
            });
            fakeUserBase.Add(new UserModel
            {
                UserName = "Mariana Cardoso", //Técnico de Qualidade
                UserCredencial = "M0002",
                UserRole = new RouterUserModel[]
                {
                    new RouterUserModel{RouterLink = "nao-conformidade", TextRouter = "Não Conformidade", IsImplements = true},
                    new RouterUserModel{RouterLink = "processos-automotivos", TextRouter = "Processos Automotivos", IsImplements = false},
                    new RouterUserModel{RouterLink = "compliance", TextRouter = "Compliance", IsImplements = true }
                }
            });
            fakeUserBase.Add(new UserModel
            {
                UserName = "Luiz Felipe", // Engenheiro
                UserCredencial = "M0003",
                UserRole = new RouterUserModel[]
                {
                    new RouterUserModel{RouterLink = "nao-conformidade", TextRouter = "Não Conformidade", IsImplements = true},
                    new RouterUserModel{RouterLink = "processos-automotivos", TextRouter = "Processos Automotivos", IsImplements = false},
                    new RouterUserModel{RouterLink = "compliance", TextRouter = "Compliance", IsImplements = true },
                    new RouterUserModel{RouterLink = "relatorios-gerenciais", TextRouter = "Relatórios Gerenciais", IsImplements = false },
                }
            });
            fakeUserBase.Add(new UserModel
            {
                UserName = "Ester Almeida", // Assistente Administrativo
                UserCredencial = "M0004",
                UserRole = new RouterUserModel[]
                {
                    new RouterUserModel{RouterLink = "nao-conformidade", TextRouter = "Não Conformidade", IsImplements = true},
                    new RouterUserModel{RouterLink = "compliance", TextRouter = "Compliance", IsImplements = true }
                }
            });
        }

    }
}
