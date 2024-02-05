using ProcessadorTarefas.Entidades;
using Repositorio;
using SOLID_Example.Interfaces;

namespace SOLID_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository<Tarefa> repository = new Repository<Tarefa>();

            //Cria 50 tarefas para ilutrarmos o funcionamento
            for (int i = 0; i < 50; i++) { 
                Tarefa tarefa = new Tarefa();
                repository.Add(tarefa);
            }

            foreach (Tarefa tarefa in repository.GetAll())
            {
                Console.WriteLine(tarefa.ToString());
            }
        }

    }
}
