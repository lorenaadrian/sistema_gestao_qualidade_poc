﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NaoConformidadeModule.WebApi.Models;
using NaoConformidadeModule.WebApi.Repository;

namespace NaoConformidadeModule.WebApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class NaoConformidadeController : ControllerBase
    {
        private INãoConformidadeRepository _naoConformidadeRepository;
        public NaoConformidadeController(INãoConformidadeRepository naoConformidadeRepository)
        {
            _naoConformidadeRepository = naoConformidadeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<NaoConformidade>> GetAll()
        {
            return await _naoConformidadeRepository.GetAllAsync();
        }

        [HttpGet("{idNC}")]
        public async Task<NaoConformidade> GetById(int idNC)
        {
            return await _naoConformidadeRepository.GetByIdAsync(idNC);
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostNaoConformidade([FromBody] NaoConformidade naoConformidade)
        {
            try
            {
                int retorno = await _naoConformidadeRepository.AddAsync(naoConformidade);
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutNaoConformidade([FromBody] NaoConformidade naoConformidade)
        {
            try
            {
                var retorno = await _naoConformidadeRepository.UpdateAsync(naoConformidade);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNaoConformidade(int id)
        {
            try
            {
                var retorno = await _naoConformidadeRepository.RemoveAsync(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
                throw;
            }
        }


    }
}