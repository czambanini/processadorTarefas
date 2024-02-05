using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessadorTarefas.Servicos
{
    public class GeradorId
    {
            private static int nextId;
            public int Id { get; private set; }

            public int AtribuirId()
            {
                Id = Interlocked.Increment(ref nextId);
                return Id;
            }
    }
}
