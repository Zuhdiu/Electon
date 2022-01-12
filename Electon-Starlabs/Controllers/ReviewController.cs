/*using AutoMapper;
using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Controllers
{
    public class AddReviewController : Controller
    {
        private readonly IReviewService _repo;
        private readonly IProductService _prod;
        private readonly IMapper _mapper;

        private AddReviewController(IReviewService reviewRepository,IProductService prod ,IMapper mapper)
        {
            _repo = reviewRepository;
            _prod = prod;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<Review> reviews = await _repo.FindAll();
            return View(reviews);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> selectListItems = await _repo.SelectListItems();
            ViewBag.Categories = selectListItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string  comment)
        {
            return View();
           *//* if (ModelState.IsValid)
            {
                var review = await _repo.Create(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }*//*
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            List<SelectListItem> selectListItems = await _repo.SelectListItems();
            ViewBag.Reviews = selectListItems;

            Review review = await _repo.FindById(Id);

            if (review != null)
            {
                ProductReviewViewModel model = _mapper.Map<ProductReviewViewModel>(review);
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _repo.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _repo.Delete(Id);
            return RedirectToAction("Index");
        }

    }
}
*/