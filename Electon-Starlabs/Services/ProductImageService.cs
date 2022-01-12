using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            this.productImageRepository = productImageRepository;
        }

        public async Task<bool> Create(ProductImageViewModel model)
        {
            foreach(var item in model.Images)
            {
                ProductImage image = new ProductImage
                {
                    ProductId = model.ProductId
                };
                byte[] pictureBytes = null;

                using (var stream = new MemoryStream())
                {
                    await item.CopyToAsync(stream);
                    pictureBytes = stream.ToArray();

                    image.ProductImg = pictureBytes;
                }
               
                var result = await productImageRepository.Create(image);
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<List<ProductImage>> FindAll(int Id)
        {
            return await productImageRepository.FindAll(Id);
        }

        public async Task<bool> Update(ProductImageViewModel model)
        {
            if(model != null)
            {
                await productImageRepository.DeleteAllPictures(model.ProductId);
                foreach (var item in model.Images)
                {
                    ProductImage image = new ProductImage
                    {
                        ProductId = model.ProductId
                    };
                    byte[] pictureBytes = null;

                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        pictureBytes = stream.ToArray();

                        image.ProductImg = pictureBytes;
                    }
                    var result = await productImageRepository.Create(image);
                    if (!result)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                throw new ArgumentException("ProductViewModel cannot be null", "ProductViewModel");
            }
        }
    }
}
