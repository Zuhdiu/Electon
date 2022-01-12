using AutoMapper;
using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepo;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            this.categoryRepo = categoryRepo;
            this.mapper = mapper;
        }

        public async Task<Category> Create(CategoryViewModel model)
        {
            Category category = mapper.Map<Category>(model);

            byte[] pictureBytes = null;

            using (var stream = new MemoryStream())
            {
                await model.Photo.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                category.Picture = pictureBytes;
            }
            return await categoryRepo.Create(category);
        } 
        
        public Category FindById(int Id)
        {
            return categoryRepo.FindById(Id);
        }
        public List<Category> FindAll()
        {
            return categoryRepo.FindAll();
        }
        public async Task<bool> Update(CategoryViewModel model)
        {
            Category category = mapper.Map<Category>(model);

            byte[] pictureBytes = null;

            using (var stream = new MemoryStream())
            {
                await model.Photo.CopyToAsync(stream);
                pictureBytes = stream.ToArray();

                category.Picture = pictureBytes;
            }

            return await categoryRepo.Update(category);
        }

        public async Task<bool> Delete(int id)
        {
            return await categoryRepo.Delete(id);
        }

        public bool isExists(int id)
        {
            return categoryRepo.isExists(id);
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
            return await categoryRepo.SelectListItems();
        }
    }
}
