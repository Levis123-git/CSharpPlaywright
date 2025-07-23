using System;
using PlaywrightTests.elementos;
using PlaywrightTests.metodos;
using Microsoft.Playwright;

namespace PlaywrightTests.pages;
public class LoginPage
{

	private readonly IPage page;
	Metodos metodo;
	LoginElements el = new LoginElements();
	public LoginPage(IPage page)
	{
		this.page = page;
		metodo = new Metodos(page);
	}

	public async Task loginSuceso(string username, string password)
	{
		await metodo.Escrever(el.usernameField, username);
        await metodo.Escrever(el.passwordField, password);
        await metodo.Clicar(el.loginBtn);
		await metodo.ValidarUrl("https://www.saucedemo.com/v1/inventory.html");
	}

	public async Task loginNegativo(string username, string password, string msgRetornada)
	{
        await metodo.Escrever(el.usernameField, username);
        await metodo.Escrever(el.passwordField, password);
        await metodo.Clicar(el.loginBtn);
		if (msgRetornada == "Epic sadface: Username and password do not match any user in this service")
		{
			await metodo.ValidarMensagemRetornada(el.errorMsg, "Epic sadface: Username and password do not match any user in this service");
        }else if (msgRetornada == "Epic sadface: Username is required")
		{
            await metodo.ValidarMensagemRetornada(el.errorMsg, "Epic sadface: Username is required");
        }


    }

}
