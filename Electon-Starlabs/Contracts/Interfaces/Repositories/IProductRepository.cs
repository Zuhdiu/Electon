using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> Create(Product Entity);
        public Task<bool> Update(Product Entity);
        public Task<bool> Delete(Product Entity);
        public Task<bool> Save();
        public bool isExists(int Id);
        public Task<List<Product>> FindAll();
        public Task<Product> FindById(int Id);
        Task<Product> GetProductByIdAsync(int id);
        public Task<List<Product>> FindByCategory(int CategoryId);
    }
}
