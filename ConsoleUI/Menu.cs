using ProcessadorTarefas.Entidades;
using ProcessadorTarefas.Servicos;
using SOLID_Example.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleUI
{
    internal class Menu
    {
        private IGerenciadorTarefas _gerenciador;

        public Menu(IGerenciadorTarefas gerenciador)
        {
            _gerenciador = gerenciador;
        }


        public static async void MenuFixo(int opcaomenu, IGerenciadorTarefas gerenciador)
        {
            while(true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("               PROCESSADOR DE TAREFAS               ");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("1. Criar Tarefa                 3. Listar tarefas");
                Console.WriteLine("2. Cancelar Tarefa              4.Voltar");
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("");


                switch (opcaomenu)
                {
                    case 1:
                        MenuCriarTarefa(gerenciador);
                        break;
                    case 2:
                        break;
                    case 3:
                        MenuListarTarefas(gerenciador);
                        break;
                    case 4:
                        await MenuProcessando(gerenciador);
                        break;
                    default:
                        break;
                }

                bool escolha = int.TryParse(Console.ReadLine(), out opcaomenu);
                Console.Clear();
                MenuFixo(opcaomenu, gerenciador);

                await Task.Delay(100);

            }

        }

        public static void MenuCriarTarefa(IGerenciadorTarefas gerenciador)
        {
            var tarefacriada = gerenciador.Criar();
            tarefacriada.ToString(); //não esta funcionando
            Console.WriteLine("Tarefa criada com sucesso");
        }

        public static async Task MenuListarTarefas(IGerenciadorTarefas gerenciador)
        {
            Console.WriteLine("TAREFAS ATIVAS");
            Console.WriteLine();

            var listaAtivas = gerenciador.ListarAtivas().GetAwaiter().GetResult();
            foreach (var item in listaAtivas)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("TAREFAS INATIVAS");
            Console.WriteLine();

            var listaInativas = await gerenciador.ListarInativas();
            foreach (var item in listaInativas)
            {
                Console.WriteLine(item.ToString());
            }

            //Console.WriteLine("Aperte qualquer tecla para voltar");
            //Console.ReadLine();
        }


        public static async Task MenuProcessando(IGerenciadorTarefas gerenciador)
        {
            Console.WriteLine("TAREFAS EM ANDAMENTO:");
            var tarefasAtivas = gerenciador.ListarAtivas().GetAwaiter().GetResult();

            foreach (var tarefa in tarefasAtivas.Where(t => t.Estado == EstadoTarefa.EmExecucao))
            {
                Console.Write($"Tarefa {tarefa.Id}".PadRight(15));

                int andamento = tarefa.SubtarefasExecutadas.Count() * 100 / (tarefa.SubtarefasExecutadas.Count() + tarefa.SubtarefasPendentes.Count());
                Console.WriteLine($"| {andamento}%");
            }
            
        //    var tarefasExecutando = await processador.ListaProcessando();
        //    foreach (var item in tarefasExecutando)
        //    {
        //        Console.WriteLine($"Tarefa {item.Id}");
        //    }
        //    Console.WriteLine("teste");
        }
    }
}
