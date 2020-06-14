using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace SistemaGestaoQualidade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcaoCorretivaController : ControllerBase
    {
        private IAcaoCorretivaRepository _acaoCorretivaRepository;
        public AcaoCorretivaController(IAcaoCorretivaRepository acaoCorretivaRepository)
        {
            _acaoCorretivaRepository = acaoCorretivaRepository;
        }

        [HttpGet]
        [Route("{idCR}/causaraiz")]
        [Authorize]
        public async Task<IEnumerable<AcaoCorretiva>> GetAcaoCorretivaByCausaRaiz(int idCR)
        {
            return await _acaoCorretivaRepository.GetAcaoByCR(idCR);
        }
    }
}
