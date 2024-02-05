using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessadorTarefas.Entidades;

namespace ProcessadorTarefas.Servicos
{
    internal class GerenciadorTarefas : IGerenciadorTarefas
    {
        public Task<Tarefa> Criar()
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa> Consultar(int idTarefa)
        {
            throw new NotImplementedException();
        }

        public Task Cancelar(int idTarefa)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> ListarAtivas()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> ListarInativas()
        {
            throw new NotImplementedException();
        }
    }
}
