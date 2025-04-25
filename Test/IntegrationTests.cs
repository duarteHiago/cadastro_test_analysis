//Esse teste esta sendo executado dentro do projeto de teste, esta aqui apenas para fins de exemplo e exibixao no repositório do github.

using CadastroTestProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace cadastro_test_analysis.Tests

{
    [TestClass]
    public class IntegrationTests
    {
        private UsuarioService _usuarioService = null!;

        [TestInitialize]
        public void Setup()
        {
            _usuarioService = new UsuarioService();
        }

        [TestMethod]
        public void CadastroELogin_DeveFuncionarCorretamente()
        {
            // Arrange
            var nome = "Teste";
            var usuarioLogin = "usuarioTeste_" + Guid.NewGuid().ToString("N");
            var senha = "senha123";

            // Act
            _usuarioService.CadastrarUsuarioSimulado(nome, usuarioLogin, senha);

            var output = new StringWriter();
            Console.SetOut(output);

            _usuarioService.LoginSimulado(usuarioLogin, senha);

            // Assert
            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("Bem-vindo"));
        }
    }
}