using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Services
{
    public interface ICategoryService 
    {
        public Task<Category> Create(CategoryViewModel entity);
        public Task<bool> Update(CategoryViewModel entity);
        public Task<bool> Delete(int Id);
        public List<Category> FindAll();
        public Category FindById(int Id);
        public bool isExists(int id);
        public Task<List<SelectListItem>> SelectListItems();
    }
}
