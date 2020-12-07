using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtividadeAula02.Models
{
    public class CEP
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cod_IBGE_Estado { get; set; }
        public string Cod_IBGE_Cidade { get; set; }

        public DateTime CriadoEm { get; set; }
    }
}
