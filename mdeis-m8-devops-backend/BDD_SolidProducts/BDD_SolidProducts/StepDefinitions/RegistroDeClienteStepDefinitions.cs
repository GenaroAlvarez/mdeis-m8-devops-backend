using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll.Assist;
using SolidProducts.Entities;
using SeleniumExtras.WaitHelpers;

namespace BDD_SolidProducts.StepDefinitions;

[Binding]
[Scope(Feature = "Registro de Cliente")]
public class RegistroDeClienteStepDefinitions
{
    private Client _client = null!;
    private string _mensaje = string.Empty;
    private IWebDriver _driver;
    private WebDriverWait _wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

    [Given("que la aplicacion esta desplegada correctamente")]
    public void GivenQueLaAplicacionEstaDesplegadaCorrectamente()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();

        _driver.Url = "http://localhost:5173/";
        Thread.Sleep(2000);
    }

    [When("el usuario ingresa los datos del cliente:")]
    public void WhenElUsuarioIngresaLosDatosDelCliente(DataTable dataTable)
    {
        dynamic data = dataTable.CreateInstance<Client>();
        _client = new Client
        {
            Code = data.Code,
            Name = data.Name,
            Email = data.Email,
            DocumentNumber = data.DocumentNumber,
            DocumentTypeId = data.DocumentTypeId
        };

        var clientFormButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("clientFormButton")));
        clientFormButton.Click();
        Thread.Sleep(1000);

        var codeInput = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("code")));
        codeInput.Clear();
        codeInput.SendKeys(_client.Code);
        Thread.Sleep(1000);

        var nameInput = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("name")));
        nameInput.Clear();
        nameInput.SendKeys(_client.Name);
        Thread.Sleep(1000);

        var docNumberInput = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("documentNumber")));
        docNumberInput.Clear();
        docNumberInput.SendKeys(_client.DocumentNumber.ToString());
        Thread.Sleep(1000);

        var emailInput = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email")));
        emailInput.Clear();
        emailInput.SendKeys(_client.Email);
        Thread.Sleep(1000);

        var selectElement = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("documentType")));
        selectElement.Click();
        Thread.Sleep(1000);

        var optionSelector = $"ul[role='listbox'] li[data-value='{_client.DocumentTypeId}']";
        var option = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(optionSelector)));
        option.Click();
        Thread.Sleep(1000);
    }

    [When("confirma el registro del cliente")]
    public void WhenConfirmaElRegistroDelCliente()
    {
        var saveButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("saveButton")));
        saveButton.Click();
    }

    [Then("se muestra el mensaje del cliente {string}")]
    public void ThenSeMuestraElMensajeDelCliente(string mensajeEsperado)
    {
        var mensajeObtenidoText = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("notistack-snackbar")));
        string mensajeObtenido = mensajeObtenidoText.Text;

        Assert.AreEqual(mensajeEsperado, mensajeObtenido);
    }

    [Then("se muestra el mensaje de error faltante {string}")]
    public void ThenSeMuestraElMensajeDeErrorFaltante(string mensajeEsperado)
    {
        var snackbar = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("code-helper-text")));
        string mensajeObtenido = snackbar.Text;

        Assert.AreEqual(mensajeEsperado, mensajeObtenido);
    }
}
