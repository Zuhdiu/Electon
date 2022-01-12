using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Services
{
    public interface IProductImageService
    {
        public Task<bool> Create(ProductImageViewModel entity);
        public Task<bool> Update(ProductImageViewModel entity);
        public Task<List<ProductImage>> FindAll(int Id);
    }
}
