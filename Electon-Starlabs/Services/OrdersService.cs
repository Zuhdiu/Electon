using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _context;
        public OrdersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)    
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Product).Where(n => n.UserId == userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, Customer customer)
        {
            var order = new Order()
            {
                UserId = customer.Id.ToString(),
                Email = customer.Email,
                FirstName = customer.Name,
                LastName = customer.Surname,
                City = customer.City,
                Address = customer.Address
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = (double)item.Product.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public Task<Customer> FindByIdentityId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
