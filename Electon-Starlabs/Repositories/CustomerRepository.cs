using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext context;

        public CustomerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Customer>> FindAll()
        {
            return await context.Customers.Include(x => x.IdentityUser).ToListAsync();
        }

        public async Task<Customer> FindById(int Id)
        {
            return await context.Customers.FindAsync(Id);
        }

        public async Task<Customer> FindByIdentityId(string id)
        {
            return  context.Customers.FirstOrDefault(x => x.IdentityUserId == id);
        }

        public async Task<bool> LockCustomer(Customer entity)
        {
            
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity.Locked;
        }
    }
}
