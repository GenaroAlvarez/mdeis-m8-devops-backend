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
                Code = "C-000001",
                DocumentNumber = 1234567,
                Email = "juan.perez@gmail.com",
                DocumentType = new DocumentType
                {
                    Id = 1,
                    Name = "ABC",
                    Code = "DOC-000001",
                },
                CreatedAt = DateTime.Now,
            };

            ProductResponseDto productResponseDto = new ProductResponseDto
            {
                Id = 1,
                Code = "P-000001",
                Name = "Taladro",
                Price = 500,
            };

            const int quantity = 5;

            var calculationResponse = Calculations.CalculationProduct(clientResponseDto, productResponseDto, quantity);
            Assert.AreEqual(275, calculationResponse.Discount);
            Assert.AreEqual(11, calculationResponse.DiscountPercentage);
            Assert.AreEqual(2225, calculationResponse.Subtotal);
        }

        [TestMethod]
        public void ProductCalculationDiscountClientTest_OK()
        {
            ClientResponseDto clientResponseDto = new ClientResponseDto
            {
                Id = 1,
                Name = "Juan Pérez",
                Code = "C-000001",
                DocumentNumber = 1234567,
                Email = "juan.perez@gmail.com",
                DocumentType = new DocumentType
                {
                    Id = 1,
                    Name = "BCD",
                    Code = "DOC-000001",
                },
                CreatedAt = DateTime.Now,
            };

            ProductResponseDto productResponseDto = new ProductResponseDto
            {
                Id = 1,
                Code = "P-000002",
                Name = "Cinturón de obrero",
                Price = 500,
            };

            const int quantity = 5;

            var calculationResponse = Calculations.CalculationProduct(clientResponseDto, productResponseDto, quantity);
            Assert.AreEqual(75, calculationResponse.Discount);
            Assert.AreEqual(3, calculationResponse.DiscountPercentage);
            Assert.AreEqual(2425, calculationResponse.Subtotal);
        }

        [TestMethod]
        public void ProductCalculationDiscountProductTest_OK()
        {
            ClientResponseDto clientResponseDto = new ClientResponseDto
            {
                Id = 1,
                Name = "Juan Carlos Chavez",
                Code = "C-000001",
                DocumentNumber = 1234567,
                Email = "juan.perez@gmail.com",
                DocumentType = new DocumentType
                {
                    Id = 1,
                    Name = "BCD",
                    Code = "DOC-000001",
                },
                CreatedAt = DateTime.Now,
            };

            ProductResponseDto productResponseDto = new ProductResponseDto
            {
                Id = 1,
                Code = "P-000001",
                Name = "Taladro",
                Price = 500,
            };

            const int quantity = 5;

            var calculationResponse = Calculations.CalculationProduct(clientResponseDto, productResponseDto, quantity);
            Assert.AreEqual(200, calculationResponse.Discount);
            Assert.AreEqual(8, calculationResponse.DiscountPercentage);
            Assert.AreEqual(2300, calculationResponse.Subtotal);
        }
    }
}