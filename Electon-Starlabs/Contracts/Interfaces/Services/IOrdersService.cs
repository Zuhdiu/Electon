using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, Customer customer);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
        Task<List<Order>> GetAll();
        public Task<Customer> FindByIdentityId(string id);

    }
}
