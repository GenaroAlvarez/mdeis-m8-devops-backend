using BDD_SolidProducts.Models;
using Reqnroll;
using Reqnroll.Assist;
using NUnit.Framework;

namespace BDD_SolidProducts.StepDefinitions;

[Binding]
[Scope(Feature = "Registro de Factura de Venta")]
public class RegistroDeFacturaDeVentaStepDefinitions
{
    private Invoice _invoice = null!;
    private string _mensaje = string.Empty;

    [Given("que la aplicacion esta desplegada correctamente")]
    public void GivenQueLaAplicacionEstaDesplegadaCorrectamente()
    {
        // Simulacion de entorno disponible
    }

    [When("el usuario ingresa los datos de la factura:")]
    public void WhenElUsuarioIngresaLosDatosDeLaFactura(DataTable table)
    {
        dynamic data = table.CreateInstance<Invoice>();
        _invoice = new Invoice
        {
            Nit = Convert.ToDecimal(data.Nit),
            BusinessName = data.BusinessName,
            ClientId = Convert.ToInt32(data.ClientId),
            PaymentConditionId = Convert.ToInt32(data.PaymentConditionId),
            Total = 0,
            Details = new List<InvoiceDetail>()
        };
    }

    [When("agrega los siguientes productos a la factura:")]
    public void WhenAgregaLosSiguientesProductos(DataTable table)
    {
        foreach (var row in table.CreateSet<InvoiceDetail>())
        {
            row.Subtotal = (row.Price * row.Quantity) - row.Discount;
            if (row.Subtotal < 0)
            {
                _mensaje = "Subtotal invalido en producto";
                return;
            }
            _invoice.Total += row.Subtotal;
            _invoice.Details.Add(row);
        }
    }

    [When("no agrega productos a la factura")]
    public void WhenNoAgregaProductosALaFactura()
    {
        _invoice.Details = new List<InvoiceDetail>();
        _invoice.Total = 0;
    }

    [When("confirma el registro de la factura")]
    public void WhenConfirmaElRegistroDeLaFactura()
    {
        if (!string.IsNullOrEmpty(_mensaje))
            return;

        _mensaje = (_invoice.Details.Count > 0 && _invoice.Total > 0)
            ? "Factura registrada exitosamente"
            : "La factura no tiene detalles validos";
    }


    [Then("se muestra el mensaje de la factura {string}")]
    public void ThenSeMuestraElMensajeDeLaFactura(string esperado)
    {
        Assert.That(_mensaje, Is.EqualTo(esperado));
    }
}
