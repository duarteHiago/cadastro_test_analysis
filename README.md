# Documentacao de Software: Sistema de Cadastro Genérico para Teste v0.1.

Este repositório contém um projeto de teste desenvolvido para um artigo sobre **A IMPORTÂNCIA DO TESTE DE SOFTWARE E SUAS APLICABILIDADES NAS DIFERENTES ÁREAS DO DESENVOLVIMENTO DE SISTEMAS**.
*Link do Artigo: https://drive.google.com/file/d/11A53qX02cd0jh7ZSvndQmxmYzouFj2-w/view?usp=sharing*

## 1- Visao Geral do Software

Este software de cadastro foi desenvolvido utilizando a linguagem de programação C# e implementado com o auxílio do framework de automação de testes MSTest. Ele serve como um estudo de caso prático para ilustrar a importância e as diversas aplicações do teste de software no ciclo de desenvolvimento de sistemas. Longe de ser um sistema de cadastro completo para uso em produção, ele serve como um ambiente controlado para a aplicação e análise de diferentes tipos de testes.

O foco principal deste projeto reside na demonstração de como as práticas de teste podem ser integradas em um sistema simples, desde os componentes mais básicos (testes unitários) até a interação entre diferentes partes do sistema (testes de integração) e a validação do software sob a perspectiva do usuário final (testes de aceitação). A escolha do C# e do MSTest permite explorar as funcionalidades de teste integradas ao ambiente .NET, amplamente utilizado no desenvolvimento de diversas aplicações.

## 2- Requisitos para Desenvolvimento

 **Sistema Operacional**: Windows
- **Versão .NET#**: v9.0 ou superior
- **Versão Microsoft.NET.Test.Sdk**: v17.13.0
- **Versão MSTest**: v3.8.3
- **Versão MySql**: v8.0.42.0
- **Ambiente de Desenvolvimento**: Qualquer um compatível com os requisitos listados acima

## **3 - Arquitetura do Sistema**

O sistema foi desenvolvido utilizando as tecnologias:

- **Backend**: C#
- **Banco de Dados**: MySql
- **Framework de Teste**: MSTest

## Estrutura dos Arquivos

```bash
/cadastro-test-analysis
   /-- Services
      |-- UsuarioServices.cs
   /-- DataBase
      |--DatabaseConnection,cs
   /-- Models
      |-- Usuario.cs
   /-- Test
      |-- BruteForceTest.cs
      |-- SqlInjectionTest.cs
/cadastro-test-analysis.Tests
   |-- IntegrationTests.cs
   |-- UsuarioServiceTests.cs
```


## 4- Instalação

Para executar este projeto, siga os seguintes passos:

1. Clone este repositório:
   ```bash
   git clone [https://github.com/duarteHiago/cadastro_test_analysis.git](https://github.com/duarteHiago/cadastro_test_analysis.git)
   ```
2. Navegue até o diretório do projeto:
   ```bash
   cd cadastro_test_analysis
   ```
3. Instale as dependências (se houver):
   ```bash
   npm install # ou yarn install, dependendo do gerenciador de pacotes
   ```
4. Execute os testes:
   ```bash
   dotnet test # ou yarn test, dependendo do gerenciador de pacotes
   ```

## Conclusão

Este repositório apresenta um sistema de cadastro simplificado desenvolvido em C# com o framework de testes MSTest. Seu principal objetivo é servir como um estudo de caso prático para o artigo sobre **A IMPORTÂNCIA DO TESTE DE SOFTWARE E SUAS APLICABILIDADES NAS DIFERENTES ÁREAS DO DESENVOLVIMENTO DE SISTEMAS**.

Através da análise da estrutura do código e dos testes implementados (unitários, de integração e, potencialmente, de aceitação), é possível observar como diferentes estratégias de teste contribuem para a garantia da qualidade e confiabilidade de um software. Este projeto demonstra, em um contexto prático, a aplicabilidade e os benefícios do teste de software em um cenário de desenvolvimento real, mesmo que em uma escala reduzida.

Esperamos que este exemplo prático seja útil para ilustrar os conceitos discutidos no artigo e para fornecer um ponto de partida para a compreensão da importância vital do teste no ciclo de vida do desenvolvimento de software.
