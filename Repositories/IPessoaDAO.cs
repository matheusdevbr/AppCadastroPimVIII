using AppCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCadastro.Repositories
{
    public interface IPessoaDAO
    {
        List<Pessoa> BuscarTodos();
        Pessoa Adicionar(Pessoa pessoa);
    }
}
