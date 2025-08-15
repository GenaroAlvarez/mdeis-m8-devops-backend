using BDD_SolidProducts.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll.Assist;
using SeleniumExtras.WaitHelpers;
using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace BDD_SolidProducts.StepDefinitions;

[Binding]
[Scope(Feature = "Registro de Factura de Venta")]
public class RegistroDeFacturaStepDefinitions
{
    private InvoiceRequestDto _invoice = null!;
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

        var link = _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("a[path='invoices']")));
        link.Click();
        Thread.Sleep(1000);
    }

    [When("el usuario ingresa los datos de la factura:")]
    public void WhenElUsuarioIngresaLosDatosDeLaFactura(DataTable table)
    {
        dynamic data = table.CreateInstance<Models.Invoice>();
        _invoice = new InvoiceRequestDto
        {
            ClientId = Convert.ToInt32(data.ClientId),
            PaymentConditionId = Convert.ToInt32(data.PaymentConditionId),
            InvoiceDetails = new List<InvoiceDetailRequest>()
        };

        var invoiceFormButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("invoiceFormButton")));
        invoiceFormButton.Click();
        Thread.Sleep(1000);

        var selectClientElement = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("selectClient")));
        selectClientElement.Click();
        Thread.Sleep(1000);

        var optionClient = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("clientItem-" + _invoice.ClientId)));
        optionClient.Click();
        Thread.Sleep(1000);

        var selectPaymentCondition = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("selectPaymentCondition")));
        selectPaymentCondition.Click();
        Thread.Sleep(1000);
        var optionPaymentCondition = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("paymentConditionItem-" + _invoice.PaymentConditionId)));
        optionPaymentCondition.Click();
        Thread.Sleep(1000);
    }

    [When("agrega los siguientes detalles de factura:")]
    public void WhenAgregaLosSiguientesDetallesDeFactura(DataTable table)
    {
        var detalles = table.CreateSet<InvoiceDetailRequest>().ToList();

        foreach (var item in detalles)
        {
            _invoice.InvoiceDetails.Add(item);

            var selectProduct = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("selectProduct")));
            selectProduct.Click();
            Thread.Sleep(1000);
            var optionProduct = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("productItem-" + item.ProductId)));
            optionProduct.Click();
            Thread.Sleep(1000);

            var quentityInput = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("quantityInput")));
            quentityInput.Clear();
            quentityInput.SendKeys(item.Quantity.ToString());
            Thread.Sleep(1000);

            var addProductButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("addProductButton")));
            addProductButton.Click();
            Thread.Sleep(1000);
        }
    }

    [When("confirma el registro de la factura")]
    public void WhenConfirmaElRegistroDeLaFactura()
    {
        var addProductButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("saveInvoiceButton")));
        addProductButton.Click();
        Thread.Sleep(1000);
    }

    [Then("se muestra el mensaje correcto de registro {string}")]
    public void ThenSeMuestraElMensajeCorrectoDeRegistro(string mensajeEsperado)
    {
        var mensajeObtenidoText = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("notistack-snackbar")));
        string mensajeObtenido = mensajeObtenidoText.Text;

        Assert.That(mensajeObtenido, Is.EqualTo(mensajeEsperado));
    }

    [Then("se muestra el mensaje de error de cantidad negativa {string}")]
    public void ThenSeMuestraElMensajeDeErrorDeCantidadNegativa(string mensajeEsperado)
    {
        var mensajeObtenidoText = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("quantityInput-helper-text")));
        string mensajeObtenido = mensajeObtenidoText.Text;

        Assert.That(mensajeObtenido, Is.EqualTo(mensajeEsperado));
    }

    [When("no agrega detalles a la factura")]
    public void WhenNoAgregaDetallesALaFactura()
    {
        _invoice.InvoiceDetails = new List<InvoiceDetailRequest>();
    }

    [Then("se muestra el mensaje de error sin detalle {string}")]
    public void ThenSeMuestraElMensajeDeErrorSinDetalle(string mensajeEsperado)
    {
        var mensajeObtenidoText = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("totalInput-helper-text")));
        string mensajeObtenido = mensajeObtenidoText.Text;

        Assert.That(mensajeObtenido, Is.EqualTo(mensajeEsperado));
    }
}
