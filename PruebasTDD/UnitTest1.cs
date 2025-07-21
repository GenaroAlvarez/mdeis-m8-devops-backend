using SolidProducts.DTOs;
using SolidProducts.Entities;
using SolidProducts.Util;

namespace PruebasTDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProductCalculationDiscountClientProductTest_OK()
        {
            ClientResponseDto clientResponseDto = new ClientResponseDto
            {
                Id = 1,
                Name = "Juan Pérez",
                Code = "Cl-000001",
                ClientGroup = new ClientGroup
                {                    
                    Name = "Especialista",
                    Code = "Cg-000001",
                    Discount = 3,
                },
                CreatedAt = DateTime.Now,
            };

            ProductResponseDto productResponseDto = new ProductResponseDto
            {
                Id = 1,
                Code = "P-000001",
                Name = "Taladro",
                Price = 500,
                Brand = "BOSH",
                ProductGroup = new ProductGroup
                {
                    Name = "Herramientas",
                    Code = "Gp-000001",
                    Discount = 8
                }
            };

            var calculationResponse = Calculations.CalculationProduct(clientResponseDto, productResponseDto, 5);
            Assert.AreEqual(11, calculationResponse.Discount);
        }

        [TestMethod]
        public void ProductCalculationDiscountClientTest_OK()
        {
            ClientResponseDto clientResponseDto = new ClientResponseDto
            {
                Id = 1,
                Name = "Juan Pérez",
                Code = "Cl-000001",
                ClientGroup = new ClientGroup
                {
                    Name = "Especialista",
                    Code = "Cg-000001",
                    Discount = 3,
                },
                CreatedAt = DateTime.Now,
            };

            ProductResponseDto productResponseDto = new ProductResponseDto
            {
                Id = 1,
                Code = "P-000002",
                Name = "Cinturón de obrero",
                Price = 500,
                Brand = "BOSH",
                ProductGroup = new ProductGroup
                {
                    Name = "Accesorio",
                    Code = "Gp-000002",
                    Discount = 0
                }
            };

            var calculationResponse = Calculations.CalculationProduct(clientResponseDto, productResponseDto, 5);
            Assert.AreEqual(3, calculationResponse.Discount);
        }

        [TestMethod]
        public void ProductCalculationDiscountProductTest_OK()
        {
            ClientResponseDto clientResponseDto = new ClientResponseDto
            {
                Id = 1,
                Name = "Juan Carlos Chavez",
                Code = "Cl-000002",
                ClientGroup = new ClientGroup
                {
                    Name = "Regular",
                    Code = "Cg-000002",
                    Discount = 0,
                },
                CreatedAt = DateTime.Now,
            };

            ProductResponseDto productResponseDto = new ProductResponseDto
            {
                Id = 1,
                Code = "P-000001",
                Name = "Taladro",
                Price = 500,
                Brand = "BOSH",
                ProductGroup = new ProductGroup
                {
                    Name = "Herramientas",
                    Code = "Gp-000001",
                    Discount = 8
                }
            };

            var calculationResponse = Calculations.CalculationProduct(clientResponseDto, productResponseDto, 5);
            Assert.AreEqual(8, calculationResponse.Discount);
        }
    }
}