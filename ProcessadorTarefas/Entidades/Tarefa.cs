using static ProcessadorTarefas.Entidades.Tarefa;
using ProcessadorTarefas.Servicos;
using System.Collections.Generic;

namespace ProcessadorTarefas.Entidades
{
    public class Tarefa : ITarefa
    {
        public int Id { get; set; }
        public EstadoTarefa Estado { get; set; }
        public DateTime IniciadaEm { get; set; }
        public DateTime EncerradaEm { get; set; }
        public IEnumerable<Subtarefa> SubtarefasPendentes { get; set; }
        public IEnumerable<Subtarefa> SubtarefasExecutadas { get; set; }

        public GeradorId geradorid = new GeradorId();


        public Tarefa()
        {
            Id = geradorid.AtribuirId();
            Estado = EstadoTarefa.Criada;

            Random random = new Random();
            int quantidadeSubtarefas = random.Next(10, 101);

            List<Subtarefa> subtarefas = new List<Subtarefa>();
            for (int i = 0; i < quantidadeSubtarefas; i++)
            {
                subtarefas.Add(new Subtarefa());
            }
            SubtarefasPendentes = subtarefas;
        }

        public override string ToString()
        {
            return $"Tarefa {Id} - {Estado} - {SubtarefasPendentes?.Count() ?? 0} Subtarefas Pendentes e {SubtarefasExecutadas?.Count() ?? 0} Subtarefas Executadas";
        }

    }


}
