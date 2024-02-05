using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_Example.Interfaces;


namespace Repositorio
{
    public class Repository<T> : IRepository<T>
    {
        private static List<T> repository = new List<T>();

        public IEnumerable<T> GetAll()
        {
            return repository;
        }

        public T? GetById(int id)
        {
            return repository.FirstOrDefault(elemento => elemento.GetType().GetProperty("Id")?.GetValue(elemento, null)?.Equals(id) ?? false);
        }
        public void Add(T entity)
        {
            repository.Add(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
            ////pegar id do t entity
            //int entityid = entity => entity.gettype().getproperty("id")?.getvalue(elemento, null) ?
            ////encontrar elemento no repositorio por id
            //var elemento = getbyid(entityid);
        }
    }
}
