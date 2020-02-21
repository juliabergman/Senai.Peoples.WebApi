using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionariosInterface
    {
        List<FuncionariosDomains> Listar();

        void Cadastrar(int id, FuncionariosDomains funcionarios);

        void Atualizar(int id, FuncionariosDomains funcionarios);

        void Deletar(int id);

        FuncionariosDomains BuscarPorId(int id);
    }
}
