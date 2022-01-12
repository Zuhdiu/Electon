using Electon_Starlabs.Contracts.Repositories;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
       
        public Customer Create(Customer customer)
        {
            if (customer != null)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return customer;
            }
            else
            {
                throw new ArgumentNullException("Customer cannot be null");
            }
        }

        public Customer Get(int Id)
        {
            Customer customer = context.Customers.Find(Id);
            if(customer != null)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }
    }
}
