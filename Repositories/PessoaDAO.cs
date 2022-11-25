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
               
            return _bancoContext.Pessoas.FirstOrDefault(x => x.Id == id);
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
            Endereco Endereco = pessoaDb.Endereco;
            Telefone Telefone = pessoaDb.Telefone;

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
            Endereco enderecoDb = _bancoContext.Enderecos.FirstOrDefault(x => x.PessoaId == pessoaDb.Id);
            Telefone telefoneDb = _bancoContext.Telefones.FirstOrDefault(x => x.PessoaId == pessoaDb.Id);
            TipoTelefone tipoTelefoneDb = _bancoContext.TipoTelefones.FirstOrDefault(x => x.TelefoneId == telefoneDb.Id);

            if (pessoaDb == null) throw new System.Exception("Erro ao excluir Pessoa");
            if (enderecoDb == null) throw new System.Exception("Erro ao excluir Endereco");
            if (telefoneDb == null) throw new System.Exception("Erro ao excluir Telefone");
            if (tipoTelefoneDb == null) throw new System.Exception("Erro ao excluir Tipo Telefone");

            _bancoContext.Enderecos.Remove(enderecoDb);
            _bancoContext.TipoTelefones.Remove(tipoTelefoneDb);
            _bancoContext.Telefones.Remove(telefoneDb);
            _bancoContext.Pessoas.Remove(pessoaDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
