using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolidProducts.DTOs;
using SolidProducts.Entities;
using SolidProducts.Interfaces;

namespace SolidProducts.Services;

public class PaymentConditionService(IUnitOfWork uow, IMapper mapper) : IPaymentConditionService
{
    private readonly IUnitOfWork _unitOfWork = uow;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<PaymentCondition>> GetAllAsync()
    {
        return await _unitOfWork.PaymentConditions.GetAllAsync();
        //    .Query()
        //    .ProjectTo<PaymentCondition>(_mapper.ConfigurationProvider)
        //   .ToListAsync();
    }
}
