using System.Threading.Tasks;
using NUnit.Framework;
using PlaywrightTests.runner;
using PlaywrightTests.pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;

namespace PlaywrightTests.testes.LoginTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Login")]
    public class LoginTests : Executa
    {
        [Test]
        [AllureSubSuite("Login com sucesso")]
        [AllureTag("positivo")]
        [AllureOwner("Levi")]
        public async Task deveRealizarLoginComSucesso()
        {
            var login = new LoginPage(Page);
            await login.loginSuceso("standard_user", "secret_sauce");
        }

        [Test]
        [AllureSubSuite("Senha inválida")]
        [AllureTag("negativo")]
        [AllureOwner("Levi")]
        public async Task naodeveRealizarLoginComSenhaInv()
        {
            var login = new LoginPage(Page);
            await login.loginNegativo("standard_user", "invalida", "Epic sadface: Username and password do not match any user in this service");
        }

        [Test]
        [AllureSubSuite("Campos em branco")]
        [AllureTag("negativo")]
        [AllureOwner("Levi")]
        public async Task naodeveRealizarLoginComCamposEmBranco()
        {
            var login = new LoginPage(Page);
            await login.loginNegativo("", "", "Epic sadface: Username is required");
        }
    }
}
