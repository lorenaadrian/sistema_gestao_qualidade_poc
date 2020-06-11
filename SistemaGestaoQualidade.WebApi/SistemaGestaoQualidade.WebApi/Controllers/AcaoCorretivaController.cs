using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaoConformidadeModule.WebApi.Models;
using NaoConformidadeModule.WebApi.Repository;

namespace NaoConformidadeModule.WebApi.Controllers
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
        public async Task<IEnumerable<AcaoCorretiva>> GetAcaoCorretivaByCausaRaiz(int idCR)
        {
            return await _acaoCorretivaRepository.GetAcaoByCR(idCR);
        }
    }
}
