using System.IO; // Para salvar o login em um arquivo
using CadastroTestProject.Services;

namespace cadastro_test_analysis.Tests
{
    public class SqlInjectionTest
    {
        public static void Run()
        {
            var usuarioService = new UsuarioService();

            Console.WriteLine("----- Teste de SQL Injection -----");

            // Gerar um valor único para o login
            var uniqueLogin = "' OR '1'='1_" + Guid.NewGuid().ToString("N");

            // Exibir o login gerado
            Console.WriteLine($"Usuário criado para teste de SQL Injection: {uniqueLogin}");

            // Salvar o login gerado em um arquivo
            File.WriteAllText("sql_injection_test_user.txt", uniqueLogin);

            // Teste de SQL Injection no cadastro
            Console.WriteLine("\nTentando SQL Injection no cadastro...");
            usuarioService.CadastrarUsuarioSimulado("Teste", uniqueLogin, "senha123");

            // Teste de SQL Injection no login
            Console.WriteLine("\nTentando SQL Injection no login...");
            usuarioService.LoginSimulado(uniqueLogin, "senha123");
        }
    }
}