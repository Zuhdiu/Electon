using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Models;
using Electon_Starlabs.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTesting.Helper;
using Xunit;

namespace UnitTesting.CustomerUnitTest
{
    public class CustomerServiceTest
    {
        private readonly Mock<ICustomerRepository> mockedCustomerRepository;
        private readonly CustomerService _sut;
        public CustomerServiceTest()
        {
            mockedCustomerRepository = new Mock<ICustomerRepository>();
            _sut = new CustomerService(mockedCustomerRepository.Object);
        }

        [Fact]
        public async void FindAll_ValidData_CustomerListReturned() {
            //Arrange
            List<Customer> customerList = CustomerHelper.CustomerListData();
            mockedCustomerRepository.Setup(x => x.FindAll()).ReturnsAsync(customerList);
            //Act

            List<Customer> resultList = await _sut.FindAll();

            //Assert
            Assert.Equal(customerList, resultList);
        }

        [Fact]
        public async void FindById_ValidData_CustomerReturned()
        {
            //Arrange
            Customer customer = CustomerHelper.CustomerData();
            mockedCustomerRepository.Setup(x => x.FindById(1)).ReturnsAsync(customer);
            //Act

            Customer result = await _sut.FindById(1);

            //Assert
            Assert.Equal(result, customer);
        }

        [Fact]
        public async void LockUser_ValidData_BoolReturned()
        {
            //Arrange
            Customer customer = CustomerHelper.CustomerData();
            mockedCustomerRepository.Setup(x => x.LockCustomer(It.IsAny<Customer>())).ReturnsAsync(!customer.Locked);
            mockedCustomerRepository.Setup(x => x.FindById(It.IsAny<int>())).ReturnsAsync(customer);


            //Act
            bool result = await _sut.LockCustomer(customer.Id);

            //Assert
            Assert.Equal(result, !customer.Locked);
        }
    }
}
