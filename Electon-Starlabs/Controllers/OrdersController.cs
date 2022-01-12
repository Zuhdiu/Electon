using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Data.Cart;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        private readonly ICustomerService _customer;
        private readonly UserManager<IdentityUser> _userManager;


        public OrdersController(IProductService productService, IProductRepository productRepository, ShoppingCart shoppingCart, IOrdersService ordersService, ICustomerService customer,UserManager<IdentityUser> userManager)
        {
            _productService = productService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
            _customer = customer;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            Customer costumer = await _customer.FindByIdentityId(userId);
            var orders =  await _ordersService.GetOrdersByUserIdAsync(userId);
            return View(orders);

        }
        [Authorize]
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }
        [Authorize]

        public async Task<IActionResult> Checkout(string firstName, string Lastname, string Address)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            Customer customer = await _customer.FindByIdentityId(userId);
            var items = _shoppingCart.GetShoppingCartItems();
            ViewBag.Customer = customer;

            return View(items);
        }

        [Authorize]
        public IActionResult GoToPayment()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items);
        }

        [Authorize]
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            
            var item = await _productService.FindById(id);
            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        [Authorize]
        public async Task<IActionResult> RemoveItemToShoppingCart(int id)
        {
            var item = await _productService.FindById(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCard(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        [Authorize]
        public async Task<IActionResult> CompleteOrder(string street)
        {
            string idOfUser = _userManager.GetUserId(HttpContext.User);
            Customer customer = await _customer.FindByIdentityId(idOfUser);
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = idOfUser;
           /* string userEmailAddress = customer.Email;
            string firstName = customer.Name;
            string lastName = customer.Surname;
            string city = customer.City;*/


           await _ordersService.StoreOrderAsync(items,customer);
            await _shoppingCart.ClearShoppingCartAsync();
 
            return View("OrderCompleted");

        }
    }
}
