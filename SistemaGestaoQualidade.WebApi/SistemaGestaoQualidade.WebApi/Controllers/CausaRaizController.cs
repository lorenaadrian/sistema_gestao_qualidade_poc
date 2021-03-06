﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SistemaGestaoQualidade.WebApi.Models;
using SistemaGestaoQualidade.WebApi.Contracts;
using System.Threading.Tasks;

namespace SistemaGestaoQualidade.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class CausaRaizController : ControllerBase
    {
        private ICausaRaizRepository _causaRaizRepository;
        public CausaRaizController(ICausaRaizRepository causaRaizRepository)
        {
            _causaRaizRepository = causaRaizRepository;
        }

        [HttpGet]
        [Route("{idNC}/naoconformidade")]
        public async Task<CausaRaiz> GetByNaoConformidade(int idNC)
        {
            return await _causaRaizRepository.GetCausaRaizByNC(idNC);
        }

        [AcceptVerbs("GET")]
        [Route("{_idNC}")]
        public async Task<int>PostCausaRaiz(int _idNC)
        {
            CausaRaiz obj = new CausaRaiz
            {
                idNC = _idNC,
                p1 = false,
                p2 = false,
                p3 = false,
                p4 = true,
                p5 = false,
                p6 = false,
                descricaoP1 = "",
                descricaoP2 = "",
                descricaoP3 = "",
                descricaoP4 = "Teste",
                descricaoP5 = "",
                descricaoP6 = ""
            };
            return await _causaRaizRepository.AddAsync(obj);
        }
    }

}