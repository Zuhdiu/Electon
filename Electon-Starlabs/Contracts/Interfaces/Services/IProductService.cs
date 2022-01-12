using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Services
{
    public interface IProductService
    {
        public Task<Product> Create(ProductViewModel entity);
        public Task<bool> Update(ProductViewModel entity);
        public Task<bool> Delete(int Id);
        public Task<List<Product>> FindAll();
        public Task<Product> FindById(int Id);
        Task<Product> GetProductByIdAsync(int id);
        public Task<List<Product>> FindByCategory(int CategoryId);
    }
}
