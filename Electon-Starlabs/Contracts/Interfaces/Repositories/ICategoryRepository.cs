using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        public Task<Category> Create(Category entity);
        public Task<bool> Update(Category entity);
        public Task<bool> Delete(int Id);
        public Task<bool> Save();
        public bool isExists(int Id);
        public List<Category> FindAll();
        public Category FindById(int Id);
        public Task<List<SelectListItem>> SelectListItems();
    }
}
