using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Repositories
{
    public interface IUserRepository
    {
        Customer Get(int Id);
        Customer Create(Customer customer);
    }
}
