using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AppCadastro.Entities;

namespace AppCadastro.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual Telefone Telefone { get; set; }


    }
}
