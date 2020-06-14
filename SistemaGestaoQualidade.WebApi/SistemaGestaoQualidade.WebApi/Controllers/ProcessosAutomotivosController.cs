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
    public class ProcessosAutomotivosController : ControllerBase
    {
        private ITipoRequisitoRepository _tipoRequisito;
        public ProcessosAutomotivosController(ITipoRequisitoRepository tipoRequisito)
        {
            _tipoRequisito = tipoRequisito;
        }

        [AcceptVerbs("GET")]
        [Route("listatiporequisito/{idTipo}")]
        [Authorize]

        public Task<IEnumerable<TipoRequisito>> GetListRequisitosById(int idTipo)
        {
            return _tipoRequisito.GetListByIdTipo(idTipo);
        }

        [AcceptVerbs("GET")]
        [Route("tiporequisito/{id}")]
        [Authorize]

        public Task<TipoRequisito> GetRequisitoById(int id)
        {
            return  _tipoRequisito.GetByIdAsync(id);
        }

    }
}
