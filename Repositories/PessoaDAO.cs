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

        public Pessoa GetById(int id)
        {
            return _bancoContext.Pessoas.FirstOrDefault(x => x.Id == id);
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

        public Pessoa Atualizar(Pessoa pessoa)
        {
            Pessoa pessoaDb = GetById(pessoa.Id);

            if (pessoaDb == null) throw new System.Exception("Erro ao atualizar dados da Pessoa");

            pessoaDb.Nome = pessoa.Nome;
            pessoaDb.Cpf = pessoa.Cpf;

            _bancoContext.Pessoas.Update(pessoaDb);
            _bancoContext.SaveChanges();

            return pessoaDb;
        }

        public bool Excluir(int id)
        {
            Pessoa pessoaDb = GetById(id);

            if (pessoaDb == null) throw new System.Exception("Erro ao excluir Pessoa");

            _bancoContext.Pessoas.Remove(pessoaDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
