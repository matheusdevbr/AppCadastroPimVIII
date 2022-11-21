using AppCadastro.Models;
using AppCadastro.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCadastro.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaDAO _pessoaDAO;
        public PessoasController(IPessoaDAO pessoaDAO)
        {
            _pessoaDAO = pessoaDAO;
        }

        public static List<Pessoa> lsPessoas = new List<Pessoa>();
        public IActionResult Index()
        {
            List<Pessoa> lsPessoas = _pessoaDAO.BuscarTodos();
            return View(lsPessoas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pessoa objeto)
        {
            _pessoaDAO.Adicionar(objeto);
            return RedirectToAction("Index");
        }
    }
}
