using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoQualidade.WebApi.Contracts;

namespace SistemaGestaoQualidade.WebApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ComplianceController : ControllerBase
    {
        private readonly ICatalogoNorma _catalogoNorma;
        public ComplianceController(ICatalogoNorma catalogoNorma)
        {
            _catalogoNorma = catalogoNorma;
        }

        [HttpGet]
        [Route("{fileName}")]
        [Authorize]

        public async Task<ActionResult> GetNorma(string fileName)
        {
            try
            {
                var retorno = await _catalogoNorma.GetNormaAsync(fileName);
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
                return new StatusCodeResult(503);
            }

        }

    }
}