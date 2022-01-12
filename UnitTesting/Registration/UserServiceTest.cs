using Electon_Starlabs.Contracts.Repositories;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Electon_Starlabs.Repositories;
using Electon_Starlabs.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTesting.UnitTest
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> mockedRepo;
        private readonly UserService _sut;

        public UserServiceTest()
        {
            mockedRepo = new Mock<IUserRepository>();
            _sut = new UserService(mockedRepo.Object);
        }

        [Fact]
        public void Create_ValidData_UserCreated()
        {
            //Arrange
            Customer customer = new Customer
            {
                Id = 111,
                Name = "Ardit",
                Surname = "Islami",
                Email = "a.i@gmail.com",
                PhoneNumber = "123456789",
                DateBirth = DateTime.Now,
                IdentityUserId = "e1975c67-22cb-463d-bdc0-71a1fb2198c3",
                Locked = false,
                City = "Ferizaj"

            };
            mockedRepo.Setup(x => x.Create(It.IsAny<Customer>())).Returns(customer);
            var expectedResult = 111;

            //Act
            var result = _sut.Create(customer);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Id);
        }
    }
}
