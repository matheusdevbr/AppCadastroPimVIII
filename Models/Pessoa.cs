﻿using System;
using System.Collections.Generic;
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
        public int EnderecoId { get; set; }
        public Endereco endereco { get; set; }
    }
}
