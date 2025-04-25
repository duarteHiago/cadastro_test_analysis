using CadastroTestProject.Models;
using MySql.Data.MySqlClient;

namespace CadastroTestProject.Services
{
    public class UsuarioService
    {
        private readonly DatabaseConnection _dbConnection = new();

        public void CadastrarUsuario()
        {
            Console.WriteLine("----- Cadastro de Usuário -----");

            var usuario = new Usuario();

            Console.Write("Nome: ");
            usuario.Nome = Console.ReadLine();

            Console.Write("Usuário: ");
            usuario.UsuarioLogin = Console.ReadLine();

            Console.Write("Senha: ");
            usuario.Senha = Console.ReadLine();

            using var connection = _dbConnection.GetConnection();

            var query = "INSERT INTO usuarios (nome, usuario_login, senha) VALUES (@Nome, @UsuarioLogin, @Senha)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@UsuarioLogin", usuario.UsuarioLogin);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);

            command.ExecuteNonQuery();

            Console.WriteLine("\nUsuário cadastrado com sucesso!");
        }

        public void Login()
        {
            Console.WriteLine("----- Login -----");

            Console.Write("Usuário: ");
            var usuarioLogin = Console.ReadLine();

            Console.Write("Senha: ");
            var senha = Console.ReadLine();

            using var connection = _dbConnection.GetConnection();

            var query = "SELECT * FROM usuarios WHERE usuario_login = @UsuarioLogin AND senha = @Senha";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@UsuarioLogin", usuarioLogin);
            command.Parameters.AddWithValue("@Senha", senha);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                var nome = reader.GetString("nome");
                Console.WriteLine($"\nBem-vindo, {nome}!");
            }
            else
            {
                Console.WriteLine("\nUsuário ou senha inválidos.");
            }
        }

        public void LoginSimulado(string usuarioLogin, string senha)
        {
            using var connection = _dbConnection.GetConnection();

            var query = "SELECT * FROM usuarios WHERE usuario_login = @UsuarioLogin AND senha = @Senha";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@UsuarioLogin", usuarioLogin);
            command.Parameters.AddWithValue("@Senha", senha);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                var nome = reader.GetString("nome");
                Console.WriteLine($"\nBem-vindo, {nome}!");
            }
            else
            {
                Console.WriteLine("\nUsuário ou senha inválidos.");
            }
        }

        public void CadastrarUsuarioSimulado(string nome, string usuarioLogin, string senha)
        {
            using var connection = _dbConnection.GetConnection();

            try
            {
                var query = "INSERT INTO usuarios (nome, usuario_login, senha) VALUES (@Nome, @UsuarioLogin, @Senha)";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@UsuarioLogin", usuarioLogin);
                command.Parameters.AddWithValue("@Senha", senha);

                command.ExecuteNonQuery();

                Console.WriteLine("\nUsuário cadastrado com sucesso!");
            }
            catch (MySqlException ex) when (ex.Number == 1062) // Código de erro 1062: Duplicate entry
            {
                Console.WriteLine("\nErro: O usuário já existe no banco de dados.");
            }
        }
    }
}