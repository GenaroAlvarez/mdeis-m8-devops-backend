using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SolidProducts.Data;
using SolidProducts.Interfaces;
using SolidProducts.Repositories;
using SolidProducts.Services;
using SolidProducts.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// FluentValidation
builder.Services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<ProductCreateDtoValidator>();

// Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientGroupService, ClientGroupService>();
builder.Services.AddScoped<IProductCalculationService, ProductCalculationService>();
builder.Services.AddScoped<IPaymentConditionService, PaymentConditionService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IDocumentTypeService, DocumentTypeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // db.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
