using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Services
{
    public interface IUserService
    {
        Customer Get(int Id);
        Customer Create(Customer customer);
    }
}
