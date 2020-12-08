using AtividadeAula02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private readonly Context _context;

        public CepAPIController(Context context)
        {
            _context = context;
        }

        // GET: api/cep/listar
        // Lista todos os endereços cadastrados na base de dados\

        [HttpGet]
        [Route("listar")]
        public IActionResult listar()
        {
            _context.ceps.ToList();


            if (_context.ceps.ToList() == null || _context.ceps.ToList().Count == 0 )
            {
                return BadRequest(new { msg = "Lista Vazia "});
            }

            return Ok(_context.ceps.ToList());
        }


        //GET: /api/cep/buscar/1
        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            var cep = _context.ceps.ToList().FirstOrDefault(x => x.Id == id);
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
            _context.ceps.Add(cep);
            _context.SaveChanges();
            return Created("", cep);
        }

        //PUT: /api/cep/alterar
        [HttpPut("{id:int}")]
        [Route("alterar/{id}")]
        public IActionResult Alterar(int id, CEP c)
        {
            if (c.Id != id)
            {
                return BadRequest(new { msg = "Id diferente do informado na URL!" });
            }
            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(c);
            //return NotFound(new { msg = "Endereço não encontrado!" });
        }

        //PUT: /api/cep/deletar
        [HttpDelete("{id:int}")]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var item = _context.ceps.ToList().FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound(new { msg = "Id não Encontrado!" });
            }

            _context.ceps.Remove(item);
            _context.SaveChanges();

            return Ok(new { msg = "Registro Excluido com Sucesso!!!" });
        }
    }
    
}
