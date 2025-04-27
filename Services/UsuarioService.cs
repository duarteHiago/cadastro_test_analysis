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

            // Verificar tentativas falhas anteriores
            var checkAttemptsQuery = "SELECT tentativas_falhas, bloqueado_ate FROM usuarios WHERE usuario_login = @UsuarioLogin";
            using var checkCommand = new MySqlCommand(checkAttemptsQuery, connection);
            checkCommand.Parameters.AddWithValue("@UsuarioLogin", usuarioLogin);

            using var reader = checkCommand.ExecuteReader();
            if (reader.Read())
            {
                var tentativasFalhas = reader.GetInt32("tentativas_falhas");
                var bloqueadoAte = reader["bloqueado_ate"] as DateTime?;

                if (bloqueadoAte.HasValue && bloqueadoAte > DateTime.Now)
                {
                    Console.WriteLine("\nConta bloqueada. Tente novamente após: " + bloqueadoAte.Value);
                    return;
                }

                reader.Close();

                // Verificar credenciais
                var query = "SELECT * FROM usuarios WHERE usuario_login = @UsuarioLogin AND senha = @Senha";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioLogin", usuarioLogin);
                command.Parameters.AddWithValue("@Senha", senha);

                using var loginReader = command.ExecuteReader();
                if (loginReader.Read())
                {
                    Console.WriteLine("\nBem-vindo, " + loginReader.GetString("nome") + "!");

                    // Resetar tentativas falhas após login bem-sucedido
                    var resetAttemptsQuery = "UPDATE usuarios SET tentativas_falhas = 0, bloqueado_ate = NULL WHERE usuario_login = @UsuarioLogin";
                    using var resetCommand = new MySqlCommand(resetAttemptsQuery, connection);
                    resetCommand.Parameters.AddWithValue("@UsuarioLogin", usuarioLogin);
                    resetCommand.ExecuteNonQuery();
                }
                else
                {
                    loginReader.Close();

                    // Incrementar tentativas falhas
                    tentativasFalhas++;
                    Console.WriteLine($"Tentativas falhas após incremento: {tentativasFalhas}");

                    var updateAttemptsQuery = "UPDATE usuarios SET tentativas_falhas = @TentativasFalhas WHERE usuario_login = @UsuarioLogin";
                    if (tentativasFalhas >= 5)
                    {
                        updateAttemptsQuery = "UPDATE usuarios SET tentativas_falhas = @TentativasFalhas, bloqueado_ate = @BloqueadoAte WHERE usuario_login = @UsuarioLogin";
                    }

                    Console.WriteLine($"Consulta de atualização: {updateAttemptsQuery}");

                    using var updateCommand = new MySqlCommand(updateAttemptsQuery, connection);
                    updateCommand.Parameters.AddWithValue("@TentativasFalhas", tentativasFalhas);
                    updateCommand.Parameters.AddWithValue("@UsuarioLogin", usuarioLogin);
                    if (tentativasFalhas >= 5)
                    {
                        updateCommand.Parameters.AddWithValue("@BloqueadoAte", DateTime.Now.AddMinutes(15)); // Bloquear por 15 minutos
                    }

                    updateCommand.ExecuteNonQuery();
                    Console.WriteLine("Consulta de atualização executada com sucesso.");

                    Console.WriteLine("\nUsuário ou senha inválidos.");
                }
            }
            else
            {
                Console.WriteLine("\nUsuário não encontrado.");
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