using AppCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCadastro.Entities
{
    public class Telefone
    {

        public int Id { get; set; }
        public int Ddd { get; set; }
        public int Numero { get; set; }

        public virtual TipoTelefone Tipo { get; set; }

        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
