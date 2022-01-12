using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService _productservice;
        private readonly ApplicationDbContext _context;
        private readonly IProductImageService _productImageService;

        public CategoryController(IProductService productService, ApplicationDbContext context, IProductImageService imgService)
        {
            _productservice = productService;
            _context = context;
            _productImageService = imgService;
        }
        public async Task<IActionResult> Index(int id)
        {
            List<Product> produktet = await _productservice.FindAll();
            ViewData["Recently"] = produktet.OrderByDescending(produktet => produktet.AddedDate).Take(3).ToList();
            ViewData["MostSale"] = produktet.OrderByDescending(produktet => produktet.Price).Take(3).ToList();
            ViewData["MostViewed"] = produktet.OrderByDescending(produktet => produktet.HitCount).Take(3).ToList();
            ViewBag.ProductImages = await _productImageService.FindAll(id);
            var model = await _productservice.FindByCategory(id);          
            return View(model);
        }
    }
}
