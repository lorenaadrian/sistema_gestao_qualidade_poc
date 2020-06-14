namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public interface IUser
    {
        public string UserCredencial { get; set; }
        public string UserName { get; set; }
        public IRoutersUser[] UserRole { get; set; }
    }
}