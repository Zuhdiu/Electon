using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Contracts.Services;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
        {
            _context = context;
            _logger = logger;
            this.productService = productService;
            this.categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            List<Category> categories = categoryService.FindAll();
            List<CategoryProducts> categoryProducts = new List<CategoryProducts>();
            foreach (var item in categories)
            {
                List<Product> productList = await productService.FindByCategory(item.Id);
                List<Product> products = productList.OrderByDescending(x => x.AddedDate).Take(8).ToList();

                List<Product> produktet = await productService.FindAll();
                ViewData["Recently"] = produktet.OrderByDescending(produktet => produktet.AddedDate).Take(3).ToList();
                ViewData["MostSale"] = produktet.OrderByDescending(produktet => produktet.Price).Take(3).ToList();
                ViewData["MostViewed"] = produktet.OrderByDescending(produktet => produktet.HitCount).Take(3).ToList();

                CategoryProducts categoryProduct = new CategoryProducts
                {
                    Category = item,
                    products = products
                };
                categoryProducts.Add(categoryProduct);
            }
            HomePageViewModel model = new HomePageViewModel
            {
                CategoryProducts = categoryProducts
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string search)
        {
            List<Product> produktet = await productService.FindAll();
            ViewData["Recently"] = produktet.OrderByDescending(produktet => produktet.AddedDate).Take(3).ToList();
            ViewData["MostSale"] = produktet.OrderByDescending(produktet => produktet.Price).Take(3).ToList();
            ViewData["MostViewed"] = produktet.OrderByDescending(produktet => produktet.HitCount).Take(3).ToList();

            ViewData["GetMusician"] = search;

            var product = from x in _context.Products select x;

            if (!String.IsNullOrEmpty(search))
            {
                product = product.Where(x => x.Name.Contains(search) || x.Description.Contains(search));
            }
            return View(await product.AsNoTracking().ToListAsync());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
