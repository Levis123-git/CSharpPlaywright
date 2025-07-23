using System;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace PlaywrightTests.metodos;
public class Metodos
{

    private readonly IPage page;

    public Metodos(IPage page)
    {
        this.page = page;
    }

    public async Task Escrever(string locator, string texto)
    {
        try
        {
            await page.FillAsync(locator, texto);
        }
        catch
        {
            throw new Exception("Não foi possivel encontrar o Elemento: " + locator);
        }
    }

    public async Task Clicar(string locator)
    {
        try
        {
            await page.ClickAsync(locator);
        }
        catch
        {
            throw new Exception("Não foi possivel encontrar o Elemento: " + locator);
        }
    }

    public async Task ValidarUrl(string urlEsperada)
    {
        try
        {
            await Expect(page).ToHaveURLAsync(urlEsperada);
        }
        catch
        {
            throw new Exception("Não foi possivel encontrar a URL" + urlEsperada);
        }
    }

    public async Task ValidarMensagemRetornada(string locator, string msgEsperada)
    {
        try
        {
            await Expect(page.Locator(locator)).ToHaveTextAsync(msgEsperada);
        }
        catch
        {
            throw new Exception("Não foi possivel encontrar o Elemento: " + locator);
        }
    }

    public async Task ValidarElementoVisivel(string locator)
    {
        try
        {
            await Expect(page.Locator(locator)).ToBeVisibleAsync();
        }
        catch
        {
            throw new Exception("Não foi possivel encontrar o Elemento: " + locator);
        }
    }

}
