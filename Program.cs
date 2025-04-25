using System.Buffers;
using CadastroTestProject.Services;
using cadastro_test_analysis.Tests; // Namespace dos testes

class Program
{
    static void Main(string[] args)
    {
        var usuarioService = new UsuarioService();

        while (true){

            Console.WriteLine("\n----- Menu -----");
            Console.WriteLine("1. Cadastrar Usuário");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Testes de Segurança");
            Console.WriteLine("4. Sair");
            Console.Write("\nEscolha uma opção: ");

            var opcao = Console.ReadLine();

            Console.Clear();

            switch (opcao)
            {
                case "1":
                    usuarioService.CadastrarUsuario();
                    break;
                case "2":
                    usuarioService.Login();
                    break;
                case "3":
                    AbrirMenuDeTestes();
                    break;
                case "4":
                    Console.WriteLine("Saindo do programa...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        }
    }

    static void AbrirMenuDeTestes()
    {
        while (true)
        {
            Console.WriteLine("\n----- Menu de Testes -----");
            Console.WriteLine("1. Teste de SQL Injection");
            Console.WriteLine("2. Teste de Brute Force");
            Console.WriteLine("3. Voltar ao menu principal");
            Console.Write("\nEscolha uma opção: ");

            var opcaoTeste = Console.ReadLine();

            Console.Clear();

            switch (opcaoTeste)
            {
                case "1":
                    SqlInjectionTest.Run();
                    break;
                case "2":
                    BruteForceTest.Run();
                    break;
                case "3":
                    return; // Voltar ao menu principal
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}