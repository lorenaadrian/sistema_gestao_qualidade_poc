using SistemaGestaoQualidade.WebApi.Contracts;

namespace SistemaGestaoQualidade.WebApi.Models
{
    public class RouterUserModel: IRoutersUser
    {
        public string TextRouter { get; set;}
        public string RouterLink { get; set; }
        public bool IsImplements { get; set; }
    }
}
