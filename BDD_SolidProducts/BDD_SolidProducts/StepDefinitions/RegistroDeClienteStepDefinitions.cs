//using BDD_SolidProducts.Models;
using Reqnroll;
using Reqnroll.Assist;
using NUnit.Framework;
using SolidProducts.Entities;

namespace BDD_SolidProducts.StepDefinitions;

[Binding]
[Scope(Feature = "Registro de Cliente")]
public class RegistroDeClienteStepDefinitions
{
    private Client _client = null!;
    private string _mensaje = string.Empty;

    [Given("que la aplicacion esta desplegada correctamente")]
    public void GivenQueLaAplicacionEstaDesplegadaCorrectamente()
    {
        // Simulación de entorno
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
    }

    [When("confirma el registro del cliente")]
    public void WhenConfirmaElRegistroDelCliente()
    {
        _mensaje = (!string.IsNullOrEmpty(_client.Code) 
                    && !string.IsNullOrEmpty(_client.Name) 
                    && !string.IsNullOrEmpty(_client.Email)
                    && _client.DocumentNumber > 0
                    && _client.DocumentTypeId > 0
                    )
            ? "Cliente registrado exitosamente"
            : "Faltan datos obligatorios";
    }

    [Then("se muestra el mensaje del cliente {string}")]
    public void ThenSeMuestraElMensajeDelCliente(string esperado)
    {
        Assert.That(_mensaje, Is.EqualTo(esperado));
    }
}
