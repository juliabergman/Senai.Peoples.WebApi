using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controller
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]

    public class FuncionariosController: ControllerBase
    {
        private IFuncionariosInterface _funcionariosRepositories { get; set; }

        public FuncionariosController()
        {
            _funcionariosRepositories = new FuncionariosRepositories();

        }
        [HttpGet]
        public IEnumerable<FuncionariosDomains> Listar()
        {
            return _funcionariosRepositories.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(int id, FuncionariosDomains novoFuncionario)
        {
            _funcionariosRepositories.Cadastrar(id, novoFuncionario);

            return StatusCode(201);
        }


        [HttpPut]
        public IActionResult Atualizar(int id, FuncionariosDomains funcionarios)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public  FuncionariosDomains BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
