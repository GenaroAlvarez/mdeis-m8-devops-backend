using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolidProducts.Entities
{
    public class Product : BaseEntity
    {
        [Required, StringLength(50)]
        public string Sku { get; set; } = null!;

        [Required, StringLength(200)]
        public string Name { get; set; } = null!;

        [StringLength(200)]
        public string? ForeignName { get; set; }

        [StringLength(100)]
        public string? ManufacturerSku { get; set; }

        [Required]
        public int ProductGroupId { get; set; }

        [ForeignKey(nameof(ProductGroupId))]
        public virtual ProductGroup ProductGroup { get; set; } = null!;

        [Required]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        [Required]
        public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public virtual Supplier Supplier { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal Weight { get; set; }

        [Required, StringLength(20)]
        public string MeasurementUnit { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(100)]
        public string? BarCode { get; set; }

        [StringLength(50)]
        public string? AlternateSku { get; set; }
    }
}
