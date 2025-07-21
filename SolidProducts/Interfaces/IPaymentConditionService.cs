using SolidProducts.DTOs;
using SolidProducts.Entities;

namespace SolidProducts.Interfaces;

public interface IPaymentConditionService
{
    Task<IEnumerable<PaymentCondition>> GetAllAsync();
}
