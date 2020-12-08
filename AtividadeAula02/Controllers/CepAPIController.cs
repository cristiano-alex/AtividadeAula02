using AtividadeAula02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadeAula02.Controllers
{
    [Route("api/cep")]
    [ApiController]
    public class CepAPIController : ControllerBase
    {
        private List<CEP> lista = new List<CEP>();

        // GET: api/cep/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult listar()
        {
            if(lista == null || lista.Count == 0 )
            {
                return BadRequest(new { msg = "Lista Vazia "});
            }

            return Ok(lista);
        }


        //GET: /api/cep/buscar/1
        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            var cep = lista.FirstOrDefault(x => x.Id == id);
            if (cep != null)
            {
                return Ok(cep);
            }
            return NotFound(new { msg = "Endereço não encontrado!" });
        }

        //POST: /api/cep/cadastrar
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(CEP cep)
        {
            cep.CriadoEm = DateTime.Now;
            lista.Add(cep);
            return Created("", lista);
        }
    }
}
