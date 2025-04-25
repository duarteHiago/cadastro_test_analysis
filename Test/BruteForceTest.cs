namespace cadastro_test_analysis.Tests
{
    using CadastroTestProject.Services;

    public class BruteForceTest
    {
        public static void Run()
        {
            var usuarioService = new UsuarioService();

            Console.WriteLine("----- Teste de Brute Force -----");

            // Simular tentativas de login com várias senhas
            var usuario = "usuarioTeste"; // Nome de usuário correto
            var senhaCorreta = "senhaCorreta"; // Senha correta

            // Cadastrar o usuário com os dados corretos
            usuarioService.CadastrarUsuarioSimulado("Teste", usuario, senhaCorreta);

            for (int i = 0; i < 10; i++)
            {
                string senha;

                if (i < 9)
                {
                    // Gerar senhas incorretas para as primeiras 9 tentativas
                    senha = $"senha{i}";
                }
                else
                {
                    // Usar a senha correta na 10ª tentativa
                    senha = senhaCorreta;
                }

                Console.WriteLine($"Tentativa {i + 1}: Usuário: {usuario}, Senha: {senha}");
                usuarioService.LoginSimulado(usuario, senha);
            }
        }
    }
}