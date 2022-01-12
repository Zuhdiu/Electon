using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<List<Customer>> FindAll()
        {
            return await customerRepository.FindAll();
        }

        public async Task<Customer> FindById(int id)
        {
            return await customerRepository.FindById(id);
        }

        public Task<Customer> FindByIdentityId(string id)
        {
            return  customerRepository.FindByIdentityId(id);
        }

        public async Task<bool> LockCustomer(int Id)
        {
            Customer customer = await customerRepository.FindById(Id);
            if(customer != null)
            {
                if (customer.Locked)
                {
                    customer.Locked = false;
                }
                else
                {
                    customer.Locked = true;
                }
                return await customerRepository.LockCustomer(customer);
            }
            else
            {
                throw new ArgumentNullException("Customer cannot be null");
            }
        }
    }
}
