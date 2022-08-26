using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class //Aceitando a criação de repositórios genéricos de algum tipo, onde o tipo seja uma classe. "Onde T seja uma classe"
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection) // ctor
            => _connection = connection;

        public IEnumerable<T> Get()
           => _connection.GetAll<T>();

        public T Get(int id)
            => _connection.Get<T>(id);

        public void Create(T model) 
        {
            //model.Id = 0; //Id sempre será zero, ao contrário, irá falhar pois no banco é identity seed.
            _connection.Insert<T>(model);
        }

        public void Update(T model)
        {
            //if (model.Id != 0)
            _connection.Update<T>(model);
        }

        public void Delete(T model)
        {
            //if (role.Id != 0)
            _connection.Delete<T>(model);
        }

        public void Delete(int id)
        {
            //if (id != 0)
            //return;  Caso seja diferente, sai da função.

            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }

    }
}
