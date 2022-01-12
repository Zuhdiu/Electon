using AutoMapper;
using Electon_Starlabs.AutoMapper;
using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Services;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Electon_Starlabs.Models;
using System.Threading.Tasks;
using UnitTesting.Helper;

namespace UnitTesting.CategoryUnitTest
{
    public  class CategoryServiceTest
    {
        private readonly Mock<ICategoryRepository> mockedRepo;
        private readonly CategoryService _sut;
        private readonly Mock<IMapper> mockedMapper;
        public CategoryServiceTest()
        {
            mockedRepo = new Mock<ICategoryRepository>();
            mockedMapper = new Mock<IMapper>();
            _sut = new CategoryService(mockedRepo.Object, mockedMapper.Object);
        }

        [Fact]
        public async Task Create_ValidData_CategoryCreatedAsync()
        {
            //Arrange
            Category category = CategoryHelper.CategoryData();
            CategoryViewModel categoryViewModel = CategoryHelper.CategoryViewModelData();

            mockedRepo.Setup(x => x.Create(It.IsAny<Category>())).ReturnsAsync(category);
            mockedMapper.Setup(x => x.Map<Category>(It.IsAny<CategoryViewModel>())).Returns(category);
            var expectedResult = "CVM";

            //Act
            var result = await _sut.Create(categoryViewModel);

            //Assert
            mockedMapper.Verify(x => x.Map<Category>(It.IsAny<CategoryViewModel>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Name);
        }

        [Fact]
        public async Task Update_ValidData_CategoryUpdatedAsync()
        {
            //Arrange
            Category category = CategoryHelper.CategoryData();
            CategoryViewModel categoryViewModel = CategoryHelper.CategoryViewModelData();
            mockedRepo.Setup(x => x.Create(It.IsAny<Category>())).ReturnsAsync(category);
            mockedMapper.Setup(x => x.Map<Category>(It.IsAny<CategoryViewModel>())).Returns(category);
            mockedRepo.Setup(x => x.Update(It.IsAny<Category>())).ReturnsAsync(true);

            //Act
            var result = await _sut.Update(categoryViewModel);

            //Assert
            Assert.True(result);
        }
        [Fact]

        public async Task Delete_ValidData_CategoryDeletedAsync()
        {
            //Arrange
            mockedRepo.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(true);

            //Act
            var result = await _sut.Delete(1);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_NotFound_CategoryNotFoundAsync()
        {
            //Arrange
            mockedRepo.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(false);

            //Act
            var result = await _sut.Delete(1);

            //Assert
            Assert.False(result);
        }
    }
}