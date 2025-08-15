using Microsoft.AspNetCore.Mvc;
using SolidProducts.DTOs;
using SolidProducts.Entities;
using SolidProducts.Interfaces;

namespace SolidProducts.Controllers;

[ApiController]
[Route("api/v1/payment-conditions")]
public class PaymentConditionController : ControllerBase
{
    private readonly IPaymentConditionService _paymentConditionService;

    public PaymentConditionController(IPaymentConditionService paymentConditionService)
    {
        _paymentConditionService = paymentConditionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentCondition>>> GetAll()
    {
        var clientGroups = await _paymentConditionService.GetAllAsync();
        return Ok(clientGroups);
    }
}