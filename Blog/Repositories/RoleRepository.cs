//using Blog.Models;
//using Dapper.Contrib.Extensions;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Blog.Repositories
//{
//    public class RoleRepository
//    {
//        private readonly SqlConnection _connection;

//        public RoleRepository(SqlConnection connection)
//           => _connection = connection;

//        public IEnumerable<Role> Get()
//            => _connection.GetAll<Role>(); 
              
//        public Role Get(int id)
//            => _connection.Get<Role>(id); 

//        public void Create(Role role) //Por ser um insert, não nos retornará nada, portanto, pode ser void.
//        {
//            role.Id = 0; //Id sempre será zero, ao contrário, irá falhar pois no banco é identity seed.
//            _connection.Insert<Role>(role);
//        }

//        public void Update(Role role)
//        {
//            if (role.Id != 0)
//                _connection.Update<Role>(role);
//        }

//        public void Delete(Role role)
//        {
//            if (role.Id != 0)
//                _connection.Delete<Role>(role);
//        }

//        public void Delete(int id)
//        {
//            if (id != 0)
//                return;// Caso seja diferente, sai da função.

//            var user = _connection.Get<User>(id);
//            _connection.Delete<User>(user);
//        }

//    }
//}
