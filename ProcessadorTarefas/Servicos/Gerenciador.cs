using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessadorTarefas.Entidades;
using SOLID_Example.Interfaces;

namespace ProcessadorTarefas.Servicos
{
    public class Gerenciador : IGerenciadorTarefas
    {
        private IRepository<Tarefa> _repositorio;

        public Gerenciador(IRepository<Tarefa> repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<Tarefa> Criar()
        {
            Tarefa novatarefa = new Tarefa();
            _repositorio.Add(novatarefa);
            return Task.FromResult(novatarefa);
        }

        public Task<Tarefa> Consultar(int idTarefa)
        {
            Tarefa tarefaconsultada = _repositorio.GetById(idTarefa);
            return Task.FromResult(tarefaconsultada);
        }

        public Task Cancelar(int idTarefa)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> ListarAtivas()
        {
            var tarefasinativas = _repositorio.GetAll().Where(t => t.Estado != EstadoTarefa.Cancelada || t.Estado != EstadoTarefa.Concluida);
            return Task.FromResult(tarefasinativas);
        }

        public Task<IEnumerable<Tarefa>> ListarInativas()
        {
            var tarefasinativas = _repositorio.GetAll().Where(t => t.Estado == EstadoTarefa.Cancelada || t.Estado == EstadoTarefa.Concluida);
            return Task.FromResult(tarefasinativas);
        }
    }
}
