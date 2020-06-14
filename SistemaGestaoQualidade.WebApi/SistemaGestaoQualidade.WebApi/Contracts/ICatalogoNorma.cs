using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Contracts
{
    public interface ICatalogoNorma
    {
        public Task<string> GetNormaAsync(string fileName);
    }
}
