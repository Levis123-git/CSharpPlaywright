﻿using System.Threading.Tasks;
using NUnit.Framework;
using PlaywrightTests.runner;
using PlaywrightTests.pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;

namespace PlaywrightTests.testes.LoginTests
{
    [TestFixture]
    public class LoginTests : Executa
    {
        [Test]
        public async Task deveRealizarLoginComSucesso()
        {
            var login = new LoginPage(Page);
            await login.loginSuceso("standard_user", "secret_sauce");
        }

        [Test]
        public async Task naodeveRealizarLoginComSenhaInv()
        {
            var login = new LoginPage(Page);
            await login.loginNegativo("standard_user", "invalida", "Epic sadface: Username and password do not match any user in this service");
        }

        [Test]
        public async Task naodeveRealizarLoginComCamposEmBranco()
        {
            var login = new LoginPage(Page);
            await login.loginNegativo("", "", "Epic sadface: Username is required");
        }
    }
}
