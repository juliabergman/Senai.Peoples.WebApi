using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionariosDomains
    {
        public int  IdFuncionarios {get;set;}
        
        //[Required] NAO DEIXA CADASTRASR SEM O NOME DO CARINHA OQO SE NÃO DA PAU DPS 
        [Required (ErrorMessage =" PARE. PARE DE COLOCAR SEM NOME AGORA ")]
        //R MAIAUSCULO!!!! tipo Deus 
    
        public string Nome { get; set; }

        // NAO DEIXA CADASTRASR SEM O NOME DO CARINHA OQO SE NÃO DA PAU DPS 
        [Required (ErrorMessage ="NAO  PODE :(........................")]
        public string Sobrenome { get; set; }
    }
}
