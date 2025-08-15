using FluentValidation;
using SolidProducts.DTOs;

namespace SolidProducts.Validators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Sku)
                .NotEmpty().WithMessage("El SKU es obligatorio.")
                .MaximumLength(50).WithMessage("El SKU no puede exceder 50 caracteres.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");

            RuleFor(x => x.ForeignName)
                .MaximumLength(200).WithMessage("El nombre alternativo no puede exceder 200 caracteres.");

            RuleFor(x => x.ManufacturerSku)
                .MaximumLength(100).WithMessage("El SKU de fabricante no puede exceder 100 caracteres.");

            RuleFor(x => x.ProductGroupId)
                .GreaterThan(0).WithMessage("Debe seleccionar un grupo de producto válido.");

            RuleFor(x => x.ManufacturerId)
                .GreaterThan(0).WithMessage("Debe seleccionar un fabricante válido.");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("Debe seleccionar un proveedor válido.");

            RuleFor(x => x.Weight)
                .GreaterThanOrEqualTo(0).WithMessage("El peso no puede ser negativo.");

            RuleFor(x => x.MeasurementUnit)
                .NotEmpty().WithMessage("La unidad de medida es obligatoria.")
                .MaximumLength(20).WithMessage("La unidad de medida no puede exceder 20 caracteres.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("El precio no puede ser negativo.");

            RuleFor(x => x.BarCode)
                .MaximumLength(100).WithMessage("El código de barras no puede exceder 100 caracteres.");

            RuleFor(x => x.AlternateSku)
                .MaximumLength(50).WithMessage("El SKU alternativo no puede exceder 50 caracteres.");
        }
    }
}
