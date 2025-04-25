using MySql.Data.MySqlClient;

namespace CadastroTestProject.Services
{
    public class DatabaseConnection
    {
        private const string ConnectionString = "Server=localhost;Database=cadastro;User=root;Password=zqkwd10011;";

        public MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}