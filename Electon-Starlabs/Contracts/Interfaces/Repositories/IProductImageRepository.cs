using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Repositories
{
    public interface IProductImageRepository
    {
        public Task<bool> Create(ProductImage entity);
        public Task<bool> DeleteAllPictures(int Id);
        public Task<List<ProductImage>> FindAll(int Id);
        public Task<bool> Save();
    }
}
