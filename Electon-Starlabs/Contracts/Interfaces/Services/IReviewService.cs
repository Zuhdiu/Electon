using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Services
{
    public interface IReviewService
    {
        public Task<Review> Create(Review entity);
        public Task<bool> Update(Review entity);
        public Task<bool> Delete(int Id);
        public Task<List<Review>> FindAll();
        public Task<Review> FindById(int Id);
        public bool isExists(int id);
        public Task<List<Review>> FindReviewsById(int Id);
        public Task<List<SelectListItem>> SelectListItems();
    }
}