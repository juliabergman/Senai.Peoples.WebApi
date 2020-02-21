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

    public class FuncionariosController: IFuncionariosInterface
    {
        private IFuncionariosInterface _funcionariosRepositories { get; set; }

        public FuncionariosController()
        {
            _funcionariosRepositories = new FuncionariosRepositories();

        }
        [HttpGet]
        public IEnumerable<FuncionariosDomains> Get()
        {
            return _funcionariosRepositories.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(int id)
        {
            throw new NotImplementedException();
        }


        [HttpPut]
        public void Atualizar(int id, FuncionariosDomains funcionarios)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public FuncionariosDomains BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public List<FuncionariosDomains> Listar()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        void IFuncionariosInterface.Cadastrar(int id)
        {
            throw new NotImplementedException();
        }

    }
}
