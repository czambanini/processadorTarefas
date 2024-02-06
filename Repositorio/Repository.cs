using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessadorTarefas.Entidades;
using SOLID_Example.Interfaces;


namespace Repositorio
{
    public class Repository : IRepository<Tarefa>
    {
        public static List<Tarefa> repository = new List<Tarefa>();

        public void GerarTarefas(int numeroTarefas)
        {
            for(int i = 0; i < numeroTarefas; i++)
            {
                Tarefa tarefa = new Tarefa();
                repository.Add(tarefa);
            }
        }

        public IEnumerable<Tarefa> GetAll()
        {
            return repository;
        }

        public Tarefa? GetById(int id)
        {
            return repository.FirstOrDefault(tarefa => tarefa.Id == id);
        }
        public void Add(Tarefa entity)
        {
            repository.Add(entity);
        }

        public void Update(Tarefa entity)
        {
            throw new NotImplementedException();
        }
    }
}
