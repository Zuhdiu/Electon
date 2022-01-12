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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Product> Create(Product entity)
        {
            await context.Products.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<bool> Delete(Product entity)
        {
            context.Products.Remove(entity);
            return await Save();
        }

        public async Task<List<Product>> FindAll()
        {
            return await context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<List<Product>> FindByCategory(int CategoryId)
        {
            return await context.Products.Where(x => x.CategoryId == CategoryId).ToListAsync();
        }

        public async Task<Product> FindById(int Id)
        {
            return await context.Products.Include(x => x.Category).Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await context.Products.FindAsync(id);

            return productDetails;
        }

        public bool isExists(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            int changes = await context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Product entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }
    }
}
