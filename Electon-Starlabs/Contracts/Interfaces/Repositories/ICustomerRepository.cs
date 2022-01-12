using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> FindAll();
        public Task<bool> LockCustomer(Customer entity);
        public Task<Customer> FindById(int Id);
        public Task<Customer> FindByIdentityId(string id);
    }
}
