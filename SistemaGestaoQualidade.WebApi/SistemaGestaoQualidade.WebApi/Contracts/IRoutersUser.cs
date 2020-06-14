
namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public interface IRoutersUser
    {
        public string TextRouter { get; set; }
        public string RouterLink { get; set; }
        public bool IsImplements { get; set; }
    }
}
