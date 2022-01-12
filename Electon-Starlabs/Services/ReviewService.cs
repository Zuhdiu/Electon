using AutoMapper;
using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Contracts.Interfaces.Services;
using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<Review> Create(Review model)
        {

            var result = await _reviewRepository.Create(model);
            Console.WriteLine(result);
            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            Review review = await _reviewRepository.FindById(Id);
            if (review != null)
            {
                return await _reviewRepository.Delete(review);
            }
            else
            {
                throw new ArgumentException("Cannot find product to delete", "Delete");
            }
        }

        public async Task<List<Review>> FindAll()
        {
            return await _reviewRepository.FindAll();
        }

        public async Task<Review> FindById(int Id)
        {
            return await _reviewRepository.FindById(Id);
        }

        public async Task<List<Review>> FindReviewsById(int Id)
        {
            return await _reviewRepository.FindReviewsById(Id);
        }

        public bool isExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
            return await _reviewRepository.SelectListItems();
        }

        public async Task<bool> Update(Review entity)
        {
            Review review = _mapper.Map<Review>(entity);
            var result = await _reviewRepository.Update(review);
            return result;
        }

    }
}