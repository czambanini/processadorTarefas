using ProcessadorTarefas.Entidades;
using Repositorio;
using SOLID_Example.Interfaces;
using ProcessadorTarefas.Configuracao;
using Microsoft.IdentityModel.Tokens;

namespace SOLID_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Repository repository = new Repository();
            repository.GerarTarefas(20);

            //testar criação das tarefas
            foreach (Tarefa item in repository.GetAll())
            {
                Console.WriteLine(item.ToString());
            }


        }

    }
}
