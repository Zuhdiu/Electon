using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting.Helper
{
    public static class CustomerHelper
    {
        public static Customer CustomerData()
        {
            Customer customer = new Customer
            {
                Id = 1,
                Name = "Filan",
                Surname = "Fisteku",
                Email = "Filan.Fisteku@gmail.com",
                Locked = false,
                PhoneNumber = "049205988",
                DateBirth = DateTime.Now,
                City = "FilanCity",
                IdentityUserId = "123124231234142"
            };
            return customer;
        }
        public static List<Customer> CustomerListData()
        {
            List<Customer> customerList = new List<Customer>();
            for(int i = 0; i< 5; i++)
            {
                Customer customer = CustomerData();
                customer.Id = i;
                customerList.Add(customer);
            }
            return customerList;
        }
    }
}
