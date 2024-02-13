using Repositorio;
using ProcessadorTarefas.Servicos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessadorTarefas.Entidades;
using SOLID_Example.Interfaces;
using System;
using System.Reflection.Metadata;

namespace ConsoleUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var serviceProvider = ConfigureServiceProvider();
            var processador = serviceProvider.GetService<IProcessadorTarefas>();
            var gerenciador = serviceProvider.GetService<IGerenciadorTarefas>();

            processador.Iniciar();

            Menu.MenuFixo(4, gerenciador);

        }

        private static IServiceProvider ConfigureServiceProvider()
        {
            string basePath = Path.GetFullPath("appsettings.json").Replace("\\bin\\Debug\\net8.0", "");

            IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile(basePath, optional: true, reloadOnChange: true)
                            .Build();

            var services = new ServiceCollection();
            services.AddScoped(_ => configuration);
            services.AddSingleton<IRepository<Tarefa>, Repository>();
            services.AddSingleton<IProcessadorTarefas, Processador>();
            services.AddScoped<IGerenciadorTarefas, Gerenciador>(serviceProvider =>
            {
                var repository = serviceProvider.GetService<IRepository<Tarefa>>();
                return new Gerenciador(repository); //configuration;
            });

            return services.BuildServiceProvider();
        }

    }


}
