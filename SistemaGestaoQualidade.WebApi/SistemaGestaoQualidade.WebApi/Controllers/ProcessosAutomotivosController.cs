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
    public class ProcessosAutomotivosController : ControllerBase
    {
        private ITipoRequisitoRepository _tipoRequisito;
        public ProcessosAutomotivosController(ITipoRequisitoRepository tipoRequisito)
        {
            _tipoRequisito = tipoRequisito;
        }

        [AcceptVerbs("GET")]
        [Route("listatiporequisito/{idTipo}")]
        public Task<IEnumerable<TipoRequisito>> GetListRequisitosById(int idTipo)
        {
            return _tipoRequisito.GetListByIdTipo(idTipo);
        }

        [AcceptVerbs("GET")]
        [Route("tiporequisito/{id}")]
        public Task<TipoRequisito> GetRequisitoById(int id)
        {
            return  _tipoRequisito.GetByIdAsync(id);
        }

    }
}
