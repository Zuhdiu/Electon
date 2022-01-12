using AutoMapper;
using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly IProductImageService productImageService;
        private readonly ApplicationDbContext _context;

        public ProductService(IProductRepository productRepository, IMapper mapper, IProductImageService productImageService, ApplicationDbContext context)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.productImageService = productImageService;
            _context = context;
        }
        public async Task<Product> Create(ProductViewModel model)
        {
            Product product = mapper.Map<Product>(model);
            product.AddedDate = DateTime.Now;
            byte[] pictureBytes = null;

            using (var stream = new MemoryStream())
            {
                await model.DefaultPhoto.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                product.DefaultImage = pictureBytes;
            }

            var result = await productRepository.Create(product);

            ProductImageViewModel productImageModel = new ProductImageViewModel
            {
                ProductId = result.Id,
                Images = model.Images
            };
            await productImageService.Create(productImageModel);
            return result;
        }

        public async Task<bool> Update(ProductViewModel model)
        {
            Product product = mapper.Map<Product>(model);
            product.AddedDate = DateTime.Now;
            byte[] pictureBytes = null;

            using (var stream = new MemoryStream())
            {
                await model.DefaultPhoto.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                product.DefaultImage = pictureBytes;
            }

            var result = await productRepository.Update(product);

            ProductImageViewModel productImageModel = new ProductImageViewModel
            {
                ProductId = model.Id,
                Images = model.Images
            };
            await productImageService.Update(productImageModel);
            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            Product product = await productRepository.FindById(Id);
            if(product != null)
            {
                return await productRepository.Delete(product);
            }
            else
            {
                throw new ArgumentException("Cannot find product to delete", "Delete");
            }
        }

        public async Task<List<Product>> FindAll()
        {
            return await productRepository.FindAll();
        }

        public async Task<Product> FindById(int Id)
        {
            return await productRepository.FindById(Id);
        }

        public async Task<List<Product>> FindByCategory(int CategoryId)
        {
            return await productRepository.FindByCategory(CategoryId);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(c => c.Category)
                .Include(c => c.DefaultImage)
                .Include(c => c.Price)
                .Include(c => c.Name)
                .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }
    }
}
