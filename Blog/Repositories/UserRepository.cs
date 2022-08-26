using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Dapper;
using System.Linq;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
            : base(connection) // Chamando construtor da classe base (Repository)
           => _connection = connection;


        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);

                    if (usr == null)
                    {
                        usr = user;

                        if (role != null)// Como há casos em que um user não tem uma role, devemos fazer essa validação para evitar erros na execução, caso seja nulo, ignora e mostra o resultado tendo role ou não.
                            usr.Roles.Add(role); // Inicializar List<Role> pelo construtor na classe User.

                        users.Add(usr);
                    }
                    else // Se já existe, adicionamos apenas a role ao usúário.
                    {
                        usr.Roles.Add(role);

                    }
                    return user;
                }, splitOn: "Id");
                
                return users;
        }
    }
}
