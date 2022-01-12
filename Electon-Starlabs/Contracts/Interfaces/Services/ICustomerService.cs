using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Services
{
    public interface ICustomerService
    {
        public Task<List<Customer>> FindAll();
        public Task<bool> LockCustomer(int Id);
        public Task<Customer> FindById(int id);
        public Task<Customer> FindByIdentityId(string id);
    }
}
