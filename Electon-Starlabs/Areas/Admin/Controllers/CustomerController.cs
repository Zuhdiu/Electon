using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await customerService.FindAll();
            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            Customer customer = await customerService.FindById(Id);
            if(customer != null)
            {
                return View(customer);

            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> LockCustomer(int Id)
        {
            bool result = await customerService.LockCustomer(Id);
            return RedirectToAction("Index");
        }
    }
}
