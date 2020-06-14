using SistemaGestaoQualidade.WebApi.Shared;

namespace SistemaGestaoQualidade.WebApi.Models
{
    public class CausaRaiz : IIdentityEntity
    {
        public int id { get; set; }
        public int idNC { get; set; }
        public bool p1 { get; set; }
        public bool p2 { get; set; }
        public bool p3 { get; set; }
        public bool p4 { get; set; }
        public bool p5 { get; set; }
        public bool p6 { get; set; }
        public string descricaoP1 { get; set; }
        public string descricaoP2 { get; set; }
        public string descricaoP3 { get; set; }
        public string descricaoP4 { get; set; }
        public string descricaoP5 { get; set; }
        public string descricaoP6 { get; set; }

    }
}
