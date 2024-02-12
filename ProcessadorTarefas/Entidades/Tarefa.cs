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
        public ICollection<Subtarefa> SubtarefasPendentes { get; set; }
        public ICollection<Subtarefa> SubtarefasExecutadas { get; set; }

        public GeradorId geradorid = new GeradorId();


        public Tarefa()
        {
            Id = geradorid.AtribuirId();
            Estado = EstadoTarefa.Criada;

            Random random = new Random();
            int quantidadeSubtarefas = random.Next(5, 11);

            List<Subtarefa> subtarefas = new List<Subtarefa>();
            for (int i = 0; i < quantidadeSubtarefas; i++)
            {
                subtarefas.Add(new Subtarefa());
            }
            SubtarefasPendentes = subtarefas;
            SubtarefasExecutadas = new List<Subtarefa>();
        }

        public override string ToString()
        {
            List<string> partes = new List<string>();

            partes.Add($"Tarefa {Id}".PadRight(15));
            partes.Add($"{Estado}".PadRight(15));
            partes.Add($"{SubtarefasPendentes?.Count()} Subtarefas Pendentes".PadRight(30));
            partes.Add($"{SubtarefasExecutadas?.Count()} Subtarefas Executadas");

            return string.Join("", partes);
        }

    }


}
