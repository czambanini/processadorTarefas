using Microsoft.Extensions.Configuration;
using ProcessadorTarefas.Entidades;
using SOLID_Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessadorTarefas.Servicos
{
    public class Processador : IProcessadorTarefas
    {
        private IRepository<Tarefa> _repositorio;
        public List<Task> tarefasExecutando = new List<Task>();
        private IConfiguration _configuracao;

        public Processador(IRepository<Tarefa> repositorio, IConfiguration configuracao)
        {
            _repositorio = repositorio;
            _configuracao = configuracao;
        }

        public async Task ProcessarSubtarefa(Subtarefa subtarefa)
        {
            await Task.Delay(subtarefa.Duracao);
        }

        public async Task ProcessarTarefa(Tarefa tarefa)
        {
            //Console.WriteLine($"Iniciando tarefa {tarefa.Id}");
            tarefa.Estado = EstadoTarefa.EmExecucao;

            foreach (Subtarefa subtarefa in tarefa.SubtarefasPendentes)
            {
                await ProcessarSubtarefa(subtarefa);
                tarefa.SubtarefasExecutadas.Add(subtarefa);
                tarefa.SubtarefasPendentes.Except(new[] { subtarefa });
            }

            tarefa.Estado = EstadoTarefa.Concluida;
        }

        public async Task<List<Task>> ListaProcessando()
        {
            await Task.WhenAny(tarefasExecutando);
            return tarefasExecutando;
        }

        public async Task Iniciar()
        {
            Queue<Tarefa> filaTarefas = new Queue<Tarefa>(_repositorio.GetAll());
            var quantidadeTaskParalelo = int.Parse(_configuracao["ExecucaoOptions:MaximoPorVez"]);
            while (tarefasExecutando.Count < quantidadeTaskParalelo) {
                Tarefa tarefa = filaTarefas.Dequeue();
                tarefasExecutando.Add(ProcessarTarefa(tarefa));
            }

            while(tarefasExecutando.Count > 0)
            {
                var tarefaConcluida = await Task.WhenAny(tarefasExecutando); //Cria uma task que será concluída quando qualquer uma das tarefas fornecidas foi concluída
                tarefasExecutando.Remove(tarefaConcluida);

                if (filaTarefas.Count > 0)
                {
                    Tarefa tarefa = filaTarefas.Dequeue();
                    tarefasExecutando.Add(ProcessarTarefa(tarefa));
                }
            }

            await Task.WhenAll(tarefasExecutando); //Cria uma task que sera completa quando todas as tasks passadas ficarem completas.

        }

        //public Task Iniciar()
        //{
        //    throw new NotImplementedException();
        //}

        public Task Encerrar()
        {
            throw new NotImplementedException();
        }

        public Task CancelarTarefa(int idTarefa)
        {

            throw new NotImplementedException();
        }
    }
}
