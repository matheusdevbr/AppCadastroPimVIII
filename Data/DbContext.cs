using AppCadastro.Entities;
using AppCadastro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCadastro.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        
       // protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
          //  modelBuilder.Entity<Pessoa>()
          //      .HasOne(a => a.Endereco)
          //      .WithOne(b => b.Pessoa)
          //      .HasForeignKey<Endereco>(b => b.PessoaId);
          //  modelBuilder.Entity<Pessoa>()
          //      .HasOne(a => a.Telefone)
          //      .WithOne(b => b.Pessoa)
          //      .HasForeignKey<Telefone>(b => b.PessoaId);
            // modelBuilder.Entity<Pessoa>().ToTable("Pessoas");
            //modelBuilder.Entity<Telefone>().ToTable("Telefones");
            //modelBuilder.Entity<Endereco>().ToTable("Enderecos");
       // }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoTelefone> TipoTelefones { get; set; }
    }
}
