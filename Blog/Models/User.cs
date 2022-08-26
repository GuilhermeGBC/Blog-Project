using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace Blog.Models
{

    [Table("[User]")]
    public class User
    {
        public User()
            => Roles = new List<Role>();
        

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Bio { get; set; }

        public string Image { get; set; }

        public string Slug { get; set; }


        [Write(false)] // Caso queiramos adicionar um USER, separadamente de um role, colocamos esta expressão para não escrever junto ao novo USER.
        public List<Role> Roles { get; set; }
    }
}
