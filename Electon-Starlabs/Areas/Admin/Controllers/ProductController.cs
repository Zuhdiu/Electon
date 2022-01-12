using AutoMapper;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Electon_Starlabs.Services;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IProductImageService productImageService;

        public ProductController(ApplicationDbContext context, IProductService productService, ICategoryService categoryService, IMapper mapper, IProductImageService productImageService)
        {
            this.context = context;
            this.productService = productService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.productImageService = productImageService;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await productService.FindAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> selectListItems = await categoryService.SelectListItems();
            ViewBag.Categories = selectListItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = await productService.Create(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            List<SelectListItem> selectListItems = await categoryService.SelectListItems();
            ViewBag.Categories = selectListItems;

            Product product = await productService.FindById(Id);

            if(product != null)
            {
                ProductReviewViewModel model = mapper.Map<ProductReviewViewModel>(product);
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await productService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            Product product = await productService.FindById(Id);
            if (product != null)
            {              
                ViewBag.ProductImages = await productImageService.FindAll(Id);
                return View(product);              
            }
            else
            {
                return NotFound();
            }

        }

        public async Task<IActionResult> Delete(int Id)
        {
            var result = await productService.Delete(Id);
            return RedirectToAction("Index");
        }


        
    }
}
