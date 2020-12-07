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
        private List<CEP> lista = new List<CEP>
        {

            new CEP {Cep = "81720240", Bairro= "Alto boqueirao"},
            new CEP {Cep = "76776734", Bairro= "teste 2" }
        };


        // GET: api/cep/listar
        [HttpGet]
        [Route("listar")]
        public List<CEP> listar()
        {
            return lista;
        }
    }
}
