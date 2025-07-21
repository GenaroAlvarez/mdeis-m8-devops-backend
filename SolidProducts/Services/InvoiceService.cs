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

    public async Task<Invoice> CreateAsync(InvoiceRequestDto request)
    {
        try
        {
            var invoice = _mapper.Map<Invoice>(request);
            foreach (var invoiceDetailRequest in request.InvoiceDetails)
            {
                var invoiceDetail = _mapper.Map<InvoiceDetail>(invoiceDetailRequest);
                invoiceDetail.WarehouseId = 1;
                invoice.Details.Add(invoiceDetail);
            }

            await _unitOfWork.Invoices.AddAsync(invoice);
            await _unitOfWork.CommitAsync();

            return invoice;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            throw;
        }
    }
}
