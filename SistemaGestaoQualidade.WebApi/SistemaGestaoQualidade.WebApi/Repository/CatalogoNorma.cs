using System.Threading.Tasks;
using CataLogoNormarService = CatalogoNormaService.CatalogoNormasClient;

namespace NaoConformidadeModule.WebApi.Repository
{
    public class CatalogoNorma : ICatalogoNorma
    {
        public CatalogoNorma()
        {
        }

        public Task<string> GetNormaAsync(string fileName)
        {
            CataLogoNormarService cliente = new CataLogoNormarService();
            var retorno =  cliente.GetNormaAsync(fileName);
            return retorno;
        }
    }
}
