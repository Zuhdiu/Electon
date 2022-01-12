using AutoMapper;
using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Models;
using Electon_Starlabs.Services;
using Electon_Starlabs.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.Helper;
using Xunit;

namespace UnitTesting.ProductImageUnitTest
{
    public class ProductImageServiceTest
    {
        private readonly Mock<IProductImageRepository> mockedProductImageRepository;
        private readonly ProductImageService _sut;
        public ProductImageServiceTest()
        {
            mockedProductImageRepository = new Mock<IProductImageRepository>();
            _sut = new ProductImageService(mockedProductImageRepository.Object);
        }

        [Fact]
        public async Task Create_ValidData_ProdcutImageCreatedAsync()
        {
            //Arrange
            ProductImage product = ProductImageHelper.ProductImageData();
            ProductImageViewModel productImageViewModel = ProductImageHelper.ProductImageViewModelData();


            mockedProductImageRepository.Setup(x => x.Create(It.IsAny<ProductImage>())).ReturnsAsync(true);
            
            //Act
            var result = await _sut.Create(productImageViewModel);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Create_InvalidData_ProdcutImageNotCreatedAsync()
        {
            //Arrange
            ProductImage product = ProductImageHelper.ProductImageData();
            ProductImageViewModel productImageViewModel = ProductImageHelper.ProductImageViewModelData();


            mockedProductImageRepository.Setup(x => x.Create(It.IsAny<ProductImage>())).ReturnsAsync(false);

            //Act
            var result = await _sut.Create(productImageViewModel);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Create_NullData_ProdcutImagesNotCreatedAsync()
        {
            //Assert
            await Assert.ThrowsAsync<ArgumentException>("ProductViewModel", () => _sut.Create(null));
        }

        [Fact]
        public async Task Update_ValidData_ProdcutImagesUpdatedAsync()
        {
            //Arrange
            ProductImageViewModel productImageViewModel = ProductImageHelper.ProductImageViewModelData();


            mockedProductImageRepository.Setup(x => x.Create(It.IsAny<ProductImage>())).ReturnsAsync(true);

            //Act
            var result = await _sut.Update(productImageViewModel);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Update_NullData_ProdcutImagesNotUpdatedAsync()
        {
            //Assert
            await Assert.ThrowsAsync<ArgumentException>("ProductViewModel", () => _sut.Update(null));
        }
    }
}
