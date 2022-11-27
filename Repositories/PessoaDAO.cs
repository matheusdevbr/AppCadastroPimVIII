using AppCadastro.Data;
using AppCadastro.Models;
using AppCadastro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            var query = _bancoContext.Pessoas
                     .Include(p => p.Endereco)
                     .Include(p => p.Telefone)
                     .Include(p => p.Telefone.Tipo)
                     .Distinct()
                     .FirstOrDefault(x => x.Id == id);
            return query;
        }

        public List<Pessoa> BuscarTodos()
        {
            var query = _bancoContext.Pessoas
                        .Include(p => p.Endereco)
                        .Include(p => p.Telefone)
                        .Include(p => p.Telefone.Tipo)
                        .Distinct()
                        .ToList();

            return query; 
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {
            Endereco Endereco = pessoa.Endereco;
            Telefone Telefone = pessoa.Telefone;
            TipoTelefone TipoTelefone = pessoa.Telefone.Tipo;

            _bancoContext.Enderecos.Add(Endereco);
            _bancoContext.TipoTelefones.Add(TipoTelefone);
            _bancoContext.Telefones.Add(Telefone);
            _bancoContext.Pessoas.Add(pessoa);
            _bancoContext.SaveChanges();

            return pessoa;
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {
            Pessoa pessoaDb = GetById(pessoa.Id);
            
            if (pessoaDb == null) throw new System.Exception("Erro ao editar Pessoa");
            
            pessoaDb.Nome = pessoa.Nome;
            pessoaDb.Cpf = pessoa.Cpf;

            pessoaDb.Endereco.Logradouro = pessoa.Endereco.Logradouro;
            pessoaDb.Endereco.Numero = pessoa.Endereco.Numero;
            pessoaDb.Endereco.Cidade = pessoa.Endereco.Cidade;
            pessoaDb.Endereco.Estado = pessoa.Endereco.Estado;
            pessoaDb.Endereco.Cep = pessoa.Endereco.Cep;
            
            pessoaDb.Telefone.Ddd = pessoa.Telefone.Ddd;
            pessoaDb.Telefone.Numero = pessoa.Telefone.Numero;

            pessoaDb.Telefone.Tipo.Tipo = pessoa.Telefone.Tipo.Tipo;

            _bancoContext.TipoTelefones.Update(pessoaDb.Telefone.Tipo);
            _bancoContext.Telefones.Update(pessoaDb.Telefone);
            _bancoContext.Enderecos.Update(pessoaDb.Endereco);
            _bancoContext.Pessoas.Update(pessoaDb);
            _bancoContext.SaveChanges();

            return pessoaDb;
        }

        public bool Excluir(int id)
        {
            Pessoa pessoaDb = GetById(id);
            
            if (pessoaDb == null) throw new System.Exception("Erro ao excluir Pessoa");

            _bancoContext.Enderecos.Remove(pessoaDb.Endereco);
            _bancoContext.TipoTelefones.Remove(pessoaDb.Telefone.Tipo) ;
            _bancoContext.Telefones.Remove(pessoaDb.Telefone);
            _bancoContext.Pessoas.Remove(pessoaDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
