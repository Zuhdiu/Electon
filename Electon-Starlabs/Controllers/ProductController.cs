using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Electon_Starlabs.Services;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Electon_Starlabs.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productservice;
        private readonly IReviewService _reviewService;
        private readonly IReviewRepository _reviewRepository;
        private readonly ApplicationDbContext _context;
        private readonly IProductImageService _productImageService;
        private readonly ICustomerService _customer;
        private readonly UserManager<IdentityUser> _userManager;
       


      

        public ProductController(IProductService productService, IReviewService reviewService, ApplicationDbContext context, IReviewRepository reviewRepository, IProductImageService imgService, ICustomerService customerService, UserManager<IdentityUser> userManager)
        {
            _productservice = productService;
            _reviewService = reviewService;
            _context = context;
            _reviewRepository = reviewRepository;
            _customer = customerService;
            _productImageService = imgService;
            _userManager = userManager;
    }
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ProductImages = await _productImageService.FindAll(id);
            var model = await _productservice.FindById(id);
            ViewData["Review"] = await _reviewService.FindReviewsById(id); 
            return View(model);

        }
        [HttpGet]
        public ActionResult CreateComment()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment(string comment, int productId)
        {
            
            Review review = new Review();
            string id = _userManager.GetUserId(HttpContext.User);

           /* var claimsIdentity = this.User;
            var user = _context.Users.FirstOrDefault(x => x.Id == id);*/

            Product product = await _productservice.FindById(productId);
            Customer costumer = await _customer.FindByIdentityId(id);
            
            review.Comment = comment;
            review.Product = product;
            review.Customer = costumer;
            review.ProductId = product.Id;
            review.CustomerId= costumer.Id;
            review.DatePublished = DateTime.Now;

          
            Console.WriteLine(comment);
            var a = this._reviewService.Create(review);
            Console.WriteLine(a);
            /*            var productreviewed = _reviewRepository.FindById(productId);
            */


            return RedirectToAction("Details", new { id = productId });

        }


    }
}