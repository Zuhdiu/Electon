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
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ApplicationDbContext context;

        public ProductImageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(ProductImage entity)
        {
            await context.ProductImages.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> DeleteAllPictures(int Id)
        {
            List<ProductImage> productImages = context.ProductImages.Where(x => x.ProductId == Id).ToList();
            foreach(var item in productImages)
            {
                context.ProductImages.Remove(item);
            }
            return await Save();
        }

        public async Task<List<ProductImage>> FindAll(int Id)
        {
            return await context.ProductImages.Where(x => x.ProductId == Id).ToListAsync();
        }

        public async Task<bool> Save()
        {
            int changes = await context.SaveChangesAsync();
            return changes > 0;
        }
    }
}
