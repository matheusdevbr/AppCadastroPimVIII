﻿// <auto-generated />
using AppCadastro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppCadastro.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20221123204344_AddTipoTelefones")]
    partial class AddTipoTelefones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppCadastro.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("AppCadastro.Entities.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ddd")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("AppCadastro.Entities.TipoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TelefoneId")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TelefoneId")
                        .IsUnique();

                    b.ToTable("TipoTelefones");
                });

            modelBuilder.Entity("AppCadastro.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Cpf")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("AppCadastro.Entities.Endereco", b =>
                {
                    b.HasOne("AppCadastro.Models.Pessoa", "Pessoa")
                        .WithOne("Endereco")
                        .HasForeignKey("AppCadastro.Entities.Endereco", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("AppCadastro.Entities.Telefone", b =>
                {
                    b.HasOne("AppCadastro.Models.Pessoa", "Pessoa")
                        .WithOne("Telefone")
                        .HasForeignKey("AppCadastro.Entities.Telefone", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("AppCadastro.Entities.TipoTelefone", b =>
                {
                    b.HasOne("AppCadastro.Entities.Telefone", "Telefone")
                        .WithOne("Tipo")
                        .HasForeignKey("AppCadastro.Entities.TipoTelefone", "TelefoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("AppCadastro.Entities.Telefone", b =>
                {
                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("AppCadastro.Models.Pessoa", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Telefone");
                });
#pragma warning restore 612, 618
        }
    }
}
