using Blog.Screens.TagScreens;
using System;
using System.Data.SqlClient;

namespace Blog
{
    public class Program
    {

        private const string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=s7s8s9s10";

        public static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(connectionString);
            Database.Connection.Open();

            Load();


            Console.ReadKey();
            Database.Connection.Close();
        }

        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu blog");
            Console.WriteLine("--------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de Usuário");
            Console.WriteLine("2 - Gestão de Perfil");
            Console.WriteLine("3 - Gestão de Categoria");
            Console.WriteLine("4 - Gestão de Tag");
            Console.WriteLine("5 - Vincular perfil/usuário");
            Console.WriteLine("6 - Vincular post/tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 4:
                    MenuTagScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}
