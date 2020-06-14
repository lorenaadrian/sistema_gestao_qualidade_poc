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
    public class ClassificacaoNaoConformidadeController : ControllerBase
    {
        private IClassificacaoNaoConformidadeRepository _classificacaoNaoConformidadeRepository;
        public ClassificacaoNaoConformidadeController(IClassificacaoNaoConformidadeRepository classificacaoNaoConformidadeRepository)
        {
            _classificacaoNaoConformidadeRepository = classificacaoNaoConformidadeRepository;
        }

        [AcceptVerbs("GET")]
        public Task<IEnumerable<ClassificacaoNaoConformidade>> GetAll()
        {
            return _classificacaoNaoConformidadeRepository.GetAllAsync();
        }

        [AcceptVerbs("GET")]
        [Route("{dominio}/dominio")]
        public Task<IEnumerable<ClassificacaoNaoConformidade>> GetByDominio(string dominio)
        {
            return _classificacaoNaoConformidadeRepository.GetListByDominio(dominio);
        }

        [AcceptVerbs("GET")]
        [Route("{tipoDominio}/tipoDominio")]
        [Authorize]
        public Task<IEnumerable<ClassificacaoNaoConformidade>> GetByTipoDominio(string tipoDominio)
        {
            return _classificacaoNaoConformidadeRepository.GetListByTipoDominio(tipoDominio);
        }

        [AcceptVerbs("GET")]
        [Route("{variosIds}")]
        [Authorize]

        public Task<IEnumerable<ClassificacaoNaoConformidade>> GetAll(string variosIds)
        {
            return _classificacaoNaoConformidadeRepository.GetListByIds(variosIds);
        }
    }
}