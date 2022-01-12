using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Areas.Admin.Controllers
{
   [Area("Admin")]
   [Authorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService _productService;
        public AdminHomeController(ApplicationDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            dashboard.customer_count = _context.Customers.Count();
            dashboard.product_count = _context.Products.Count();
            dashboard.order_count = _context.Orders.Count();
            dashboard.image_count = _context.ProductImages.Count();

            List<Product> produktet =await _productService.FindAll();
            ViewData["Recently"] = produktet.OrderByDescending(produktet => produktet.AddedDate).Take(4).ToList();

            return View(dashboard);
        }
    }
}
