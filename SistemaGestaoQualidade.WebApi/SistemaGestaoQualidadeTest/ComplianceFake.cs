using SistemaGestaoQualidade.WebApi.Contracts;
using System.Threading.Tasks;

namespace SistemaGestaoQualidadeTest
{
    public class ComplianceFake : ICatalogoNorma
    {
        public Task<string> GetNormaAsync(string fileName)
        {
            return new Task<string>(fakeGetNorma);
        }

        private string fakeGetNorma()
        {
            return "ok";
        }
    }
}
