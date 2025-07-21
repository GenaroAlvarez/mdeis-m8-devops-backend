using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolidProducts.DTOs;
using SolidProducts.Entities;
using SolidProducts.Interfaces;

namespace SolidProducts.Services;

public class InvoiceService(IUnitOfWork uow, IMapper mapper) : IInvoiceService
{
    private readonly IUnitOfWork _unitOfWork = uow;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(InvoiceRequestDto request)
    {
        var invoice = _mapper.Map<Invoice>(request);
        await _unitOfWork.Invoices.AddAsync(invoice);
        await _unitOfWork.CommitAsync();
    }
}
