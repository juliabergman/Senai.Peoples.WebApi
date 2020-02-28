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
    [Route("api/[controller]")]
    [ApiController]

    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosInterface _funcionariosRepositories { get; set; }

        public FuncionariosController()
        {
            _funcionariosRepositories = new FuncionariosRepositories();

        }
        [HttpGet]
        public IEnumerable <FuncionariosDomains> Listar()
        {
            return _funcionariosRepositories.Listar();
        }
        
        //cadastrando o amigo 
        [HttpPost]
        public IActionResult Cadastrar(int id, FuncionariosDomains novoFuncionario)
        {
            if(novoFuncionario.Nome == null){
                return BadRequest("Nome obrigatório, poxa!");
            }
            if (novoFuncionario.Sobrenome == null)
            {
                return BadRequest("Sobrenome obrigatório, poxa!");
            }
            
            _funcionariosRepositories.Cadastrar(id, novoFuncionario);

            return Created("http:localhost:500/api/Funcionarios", novoFuncionario);
        }

        //atualizando o carinha
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
           FuncionariosDomains funcionarioBuscado = _funcionariosRepositories.BuscarPorId(id);
            try{

                _funcionariosRepositories.Deletar(funcionarioBuscado.IdFuncionarios);
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
}
