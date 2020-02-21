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

    public class FuncionariosController : ControllerBase
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
            if (_funcionariosRepositories.BuscarPorId(funcionarios.IdFuncionarios) == null)
            {
                return BadRequest("Funcionário não encontrado :( ");
            }

            try {
                _funcionariosRepositories.Atualizar(id, funcionarios);
            return Ok();
            } catch (Exception e) {
                return BadRequest(e);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _funcionariosRepositories.Deletar(id);
            try{

                _funcionariosRepositories.Deletar(id);
                return Ok("Funcionário deletado! ");
            }catch(Exception e){
                return BadRequest(e);

            }

            

        }

        [HttpGet("{id}")]
        public FuncionariosDomains BuscarPorId(int id)
        {

            FuncionariosDomains funcionarioBuscado = _funcionariosRepositories.BuscarPorId(id);

            return funcionarioBuscado;
        }
    }
