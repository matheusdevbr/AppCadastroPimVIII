using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCadastro.Entities
{
    public class TipoTelefone
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public int TelefoneId { get; set; }
        public virtual Telefone Telefone { get; set; }
    }
}
