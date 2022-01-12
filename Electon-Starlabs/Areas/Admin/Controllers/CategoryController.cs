using AutoMapper;
using Electon_Starlabs.Models;
using Electon_Starlabs.Services;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electon_Starlabs.Contracts;
using Electon_Starlabs.Contracts.Interfaces.Services;
using System.IO;

namespace Electon_Starlabs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            List<Category> categories = categoryService.FindAll().ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await categoryService.Create(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            Category category = categoryService.FindById(Id);
            if(category != null)
            {
                CategoryViewModel model = mapper.Map<CategoryViewModel>(category);
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await categoryService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult> Delete(int Id)
        {
            bool result = await categoryService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
