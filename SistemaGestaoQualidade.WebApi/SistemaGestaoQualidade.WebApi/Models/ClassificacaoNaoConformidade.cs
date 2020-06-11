using NaoConformidadeModule.WebApi.Shared;

namespace NaoConformidadeModule.WebApi.Models
{
    public class ClassificacaoNaoConformidade : IIdentityEntity
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string tipoDominio { get; set; }
        public string textoDominio { get; set; }
        public string dominioAplicacao { get; set; }
    }
}
