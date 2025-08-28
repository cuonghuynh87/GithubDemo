using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace UnitTest
{
    public class ProductsControllerTest
    {
        private Mock<AppDbContext> _mockApplicationDbContext;
        private Mock<IProductRepo> _mockProductService;
        private IProductRepo _productService;

        public ProductsControllerTest()
        {
            _mockApplicationDbContext = new Mock<AppDbContext>();
            _mockProductService = new Mock<IProductRepo>();
            //_productService = new ProductService(_mockApplicationDbContext.Object);
        }

        [Fact]
        public async Task CreateProduct_ValidData_ReturnOk()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Parse("47cd9a95-2e36-47d7-b93e-2b1f911d6e1c"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = "Product 3",
                Description = "Product 3 description",
            };

            _mockProductService.Setup(x => x.CreateProduct(product)).ReturnsAsync(product);
            var controller = new ProductController(_mockProductService.Object);

            // Act
            var response = await controller.CreateProduct(product);
            var result = response.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_InValidData_ReturnNull()
        {
            // Arrange
            Product product = null;

            _mockProductService.Setup(x => x.CreateProduct(product)).ReturnsAsync(product);
            var controller = new ProductController(_mockProductService.Object);

            // Act
            var response = await controller.CreateProduct(product);
            var result = response.Result as NotFoundResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.NotFound, result?.StatusCode);
        }

        [Fact]
        public async Task CreateProduct_InValidData_ReturnBadRequest()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Empty,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = "Product 3",
                Description = "Product 3 description",
            };

            _mockProductService.Setup(x => x.CreateProduct(product)).ReturnsAsync(product);
            var controller = new ProductController(_mockProductService.Object);

            // Act
            var response = await controller.CreateProduct(product);
            var result = response.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, result?.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_ValidData_ReturnOk()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Parse("47cd9a95-2e36-47d7-b93e-2b1f911d6e1c"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = "Product 3",
                Description = "Product 3 description",
            };

            _mockProductService.Setup(x => x.UpdateProduct(product)).Returns(Task.CompletedTask);
            var controller = new ProductController(_mockProductService.Object);

            // Act
            var response = await controller.UpdateProduct(product.Id.ToString(), product);
            var result = response as OkResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
        }

        [Fact]
        public async Task UpdateProduct_InValidData_ReturnBadRequest()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Parse("47cd9a95-2e36-47d7-b93e-2b1f911d6e1c"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = "Product 3",
                Description = "Product 3 description",
            };

            _mockProductService.Setup(x => x.UpdateProduct(product)).Returns(Task.CompletedTask);
            var controller = new ProductController(_mockProductService.Object);

            // Act
            var response = await controller.UpdateProduct(Guid.NewGuid().ToString(), product);
            var result = response as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, result?.StatusCode);
        }

        [Fact]
        public async Task RemoveProduct_ValidData_ReturnOk()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Parse("47cd9a95-2e36-47d7-b93e-2b1f911d6e1c"),
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = "Product 3",
                Description = "Product 3 description",
            };

            _mockProductService.Setup(x => x.GetProductById(product.Id)).ReturnsAsync(product);
            _mockProductService.Setup(x => x.RemoveProduct(product)).Returns(Task.CompletedTask);
            var controller = new ProductController(_mockProductService.Object);

            // Act
            var response = await controller.RemoveProduct(product.Id.ToString());
            var result = response as OkResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
        }

        [Fact]
        public async Task RemoveProduct_InValidData_ReturnBadRequest()
        {
            // Arrange
            var product = new Product
            {
                Id = Guid.Empty,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = "Product 3",
                Description = "Product 3 description",
            };

            _mockProductService.Setup(x => x.RemoveProduct(product)).Returns(Task.CompletedTask);
            var controller = new ProductController(_mockProductService.Object);

            // Act
            var response = await controller.RemoveProduct(product.Id.ToString());
            var result = response as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, result?.StatusCode);
        }

        [Fact]
        public async Task SearchProducts_ValidData_ReturnOk()
        {
            // Arrange
            var searchText = "product 1";
            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Product 1",
                    Description = "Product 1 description",
                }
            };

            _mockProductService.Setup(x => x.SearchProducts(searchText)).ReturnsAsync(products);
            var controller = new ProductController(_mockProductService.Object);

            // Act
            var response = await controller.SearchProducts(searchText);
            var result = response.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
        }

        [Fact]
        public async Task SearchProducts_InValidData_ReturnBadRequest()
        {
            // Arrange
            var searchText = "";
            var controller = new ProductController(_mockProductService.Object);

            // Act
            var response = await controller.SearchProducts(searchText);
            var result = response.Result as BadRequestObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, result?.StatusCode);
        }
    }
}
