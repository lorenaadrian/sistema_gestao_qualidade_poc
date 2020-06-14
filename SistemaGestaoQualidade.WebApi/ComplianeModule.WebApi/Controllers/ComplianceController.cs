using Microsoft.AspNetCore.Mvc;
using CatalogoService;
using System.Threading.Tasks;
using System;

namespace ComplianeModule.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplianceController : ControllerBase
    {
        [HttpGet]
        [Route("{fileName}")]
        public async Task<ActionResult> GetNorma(string fileName)
        {
            try
            {
                CatalogoService.CatalogoNormasClient client = new CatalogoNormasClient();
                var retorno = await client.GetNormaAsync(fileName);
                if (retorno == null)
                {
                    return NotFound();
                }
                else
                {
                    return File(Convert.FromBase64String(retorno),
                                "application/pdf",
                                string.Format("{0}.pdf", fileName));
                }
            }
            catch (Exception)
            {
                /*
                 * Tratamento da exceção em caso de falha. 
                 */
                return new StatusCodeResult(503);
            }

        }
    }
}
