//Esse teste esta sendo executado dentro do projeto de teste, esta aqui apenas para fins de exemplo e exibixao no repositório do github.

using CadastroTestProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cadastro_test_analysis.Tests
{
    [TestClass]
    public class UsuarioServiceTests
    {
        private UsuarioService _usuarioService = null!;

        [TestInitialize]
        public void Setup()
        {
            _usuarioService = new UsuarioService();
        }

        [TestMethod]
        public void CadastrarUsuarioSimulado_ShouldNotThrowException()
        {
            // Arrange
            var nome = "Teste";
            var usuarioLogin = "usuarioTeste_" + Guid.NewGuid().ToString("N");
            var senha = "senha123";

            // Act & Assert
            try
            {
                _usuarioService.CadastrarUsuarioSimulado(nome, usuarioLogin, senha);
                Assert.IsTrue(true); // Passa se não lançar exceção
            }
            catch
            {
                Assert.Fail("O método lançou uma exceção inesperada.");
            }
        }
    }
}