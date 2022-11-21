using AppCadastro.Data;
using AppCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCadastro.Repositories
{
    public class PessoaDAO : IPessoaDAO
    {
        private readonly BancoContext _bancoContext;
        public PessoaDAO(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Pessoa> BuscarTodos()
        {
            return _bancoContext.Pessoas.ToList();
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {
            _bancoContext.Pessoas.Add(pessoa);
            _bancoContext.SaveChanges();

            return pessoa;
        }


    }
}
