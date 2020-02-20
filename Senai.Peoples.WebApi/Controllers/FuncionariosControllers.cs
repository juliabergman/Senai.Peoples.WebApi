using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FuncionariosControllers : ControllerBase
    {
        private IFuncionariosInterface _funcionariosInterface { get; set; }

    public FuncionariosControllers()
        {
            _funcionariosRepositories = new FuncionariosRepositories();
                
        }
    }

}
