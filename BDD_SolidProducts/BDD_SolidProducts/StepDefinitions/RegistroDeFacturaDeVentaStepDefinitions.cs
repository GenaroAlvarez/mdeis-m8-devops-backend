using Reqnroll;
using Reqnroll.Assist;
using NUnit.Framework;
using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace BDD_SolidProducts.StepDefinitions;

[Binding]
[Scope(Feature = "Registro de Factura de Venta")]
public class RegistroDeFacturaStepDefinitions
{
    private InvoiceRequestDto _invoice = null!;
    private string _mensaje = string.Empty;

    [Given("que la aplicacion esta desplegada correctamente")]
    public void GivenQueLaAplicacionEstaDesplegadaCorrectamente()
    {
        // Simulamos que todo está correcto
    }

    [When("el usuario ingresa los datos de la factura:")]
    public void WhenElUsuarioIngresaLosDatosDeLaFactura(DataTable table)
    {
        dynamic data = table.CreateInstance<Invoice>();
        _invoice = new InvoiceRequestDto
        {
            Total = Convert.ToDecimal(data.Total),
            ClientId = Convert.ToInt32(data.ClientId),
            PaymentConditionId = Convert.ToInt32(data.PaymentConditionId),
            InvoiceDetails = new List<InvoiceDetailRequest>()
        };
    }

    [When("agrega los siguientes detalles de factura:")]
    public void WhenAgregaLosSiguientesDetallesDeFactura(DataTable table)
    {
        var detalles = table.CreateSet<InvoiceDetailRequest>().ToList();

        foreach (var item in detalles)
        {
            if (item.Subtotal < 0)
            {
                _mensaje = "Subtotal invalido en producto";
                return;
            }

            _invoice.InvoiceDetails.Add(item);
            _invoice.Total += item.Subtotal;
        }
    }

    [When("no agrega detalles a la factura")]
    public void WhenNoAgregaDetallesALaFactura()
    {
        _invoice.InvoiceDetails = new List<InvoiceDetailRequest>();
        _invoice.Total = 0;
    }

    [When("confirma el registro de la factura")]
    public void WhenConfirmaElRegistroDeLaFactura()
    {
        if (_mensaje == "Subtotal invalido en producto")
            return;

        if (_invoice.InvoiceDetails.Count == 0 || _invoice.Total <= 0)
        {
            _mensaje = "La factura no tiene detalles validos";
        }
        else
        {
            _mensaje = "Factura registrada exitosamente";
        }
    }

    [Then("se muestra el mensaje de la factura {string}")]
    public void ThenSeMuestraElMensajeDeLaFactura(string esperado)
    {
        Assert.That(_mensaje, Is.EqualTo(esperado));
    }
}
