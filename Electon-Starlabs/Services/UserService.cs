using Electon_Starlabs.Contracts.Repositories;
using Electon_Starlabs.Contracts.Services;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Electon_Starlabs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Services
{
    
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Customer Create(Customer customer)
        {
            return userRepository.Create(customer);
        }
        public Customer Get(int Id)
        {
            return userRepository.Get(Id);
        }
    }
}
