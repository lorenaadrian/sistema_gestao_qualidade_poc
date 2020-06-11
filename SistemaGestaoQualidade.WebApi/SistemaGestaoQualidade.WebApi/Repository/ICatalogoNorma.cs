using System.Threading.Tasks;

namespace NaoConformidadeModule.WebApi.Repository
{
    public interface ICatalogoNorma
    {
        public Task<string> GetNormaAsync(string fileName);
    }
}
