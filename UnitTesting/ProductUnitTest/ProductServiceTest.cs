/*using AutoMapper;
using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Models;
using Electon_Starlabs.Services;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.Helper;
using Xunit;

namespace UnitTesting.ProductUnitTest
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> mockedProductRepository;
        private readonly Mock<IProductImageService> mockedProductImageService;
        private readonly Mock<IMapper> mockedMapper;
        private readonly ProductService _sut;
        public ProductServiceTest()
        {
            mockedProductRepository = new Mock<IProductRepository>();
            mockedMapper = new Mock<IMapper>();
            mockedProductImageService = new Mock<IProductImageService>();
            _sut = new ProductService(mockedProductRepository.Object, mockedMapper.Object, mockedProductImageService.Object);
        }

        [Fact]
        public async Task Create_ValidData_ProductCreatedAsync()
        {
            //Arrange
            Product product = ProductHelper.ProductData();
            ProductViewModel productViewModel = ProductHelper.ProductViewModelData();

            mockedProductRepository.Setup(x => x.Create(It.IsAny<Product>())).ReturnsAsync(product);
            mockedMapper.Setup(x => x.Map<Product>(It.IsAny<ProductReviewViewModel>())).Returns(product);
            string expectedResult = "Product";

            //Act
            Product result = await _sut.Create(productViewModel);

            //Assert
            mockedMapper.Verify(x => x.Map<Product>(It.IsAny<ProductReviewViewModel>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Name);
        }

        [Fact]
        public async Task Update_ValidData_ProductUpdatedAsync()
        {
            //Arrange
            Product product = ProductHelper.ProductData();
            ProductViewModel productViewModel = ProductHelper.ProductViewModelData();

            mockedProductRepository.Setup(x => x.Update(It.IsAny<Product>())).ReturnsAsync(true);
            mockedMapper.Setup(x => x.Map<Product>(It.IsAny<ProductReviewViewModel>())).Returns(product);

            //Act
            bool result = await _sut.Update(productViewModel);

            //Assert
            mockedMapper.Verify(x => x.Map<Product>(It.IsAny<ProductReviewViewModel>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task FindAll_ValidList_ProductListReturned()
        {
            //Arrange
            List<Product> products = ProductHelper.ProductListData();
            mockedProductRepository.Setup(x => x.FindAll()).ReturnsAsync(products);

            //Act
            List<Product> returnedProducts = await _sut.FindAll();

            //Assert
            Assert.Equal(products, returnedProducts);
        }

        [Fact]
        public async Task FindById_ValidProduct_ProductReturned()
        {
            //Arrange
            Product product = ProductHelper.ProductData();
            mockedProductRepository.Setup(x => x.FindById(It.IsAny<int>())).ReturnsAsync(product);

            //Act
            Product returnedProduct = await _sut.FindById(1);

            //Assert
            Assert.Equal(product, returnedProduct);
        }

        [Fact]
        public async Task Delete_ValidProduct_ProductDeleted()
        {
            //Arrange
            Product product = ProductHelper.ProductData();
            mockedProductRepository.Setup(x => x.FindById(It.IsAny<int>())).ReturnsAsync(product);
            mockedProductRepository.Setup(x => x.Delete(It.IsAny<Product>())).ReturnsAsync(true);

            //Act
            bool result = await _sut.Delete(product.Id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_InvalidProduct_ProductNotFound()
        {
            //Arrange
            await Assert.ThrowsAsync<ArgumentException>("Delete",() => _sut.Delete(7));
        }
    }
}
*/