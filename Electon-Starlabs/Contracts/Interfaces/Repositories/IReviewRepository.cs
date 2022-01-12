using Electon_Starlabs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Contracts.Interfaces.Repositories
{
    public interface IReviewRepository
    {
        public Task<Review> Create(Review entity);
        public Task<bool> Update(Review entity);
        public Task<bool> Delete(Review entity);
        public Task<bool> Save();
        public Task<List<Review>> FindAll();
        public Task<Review> FindById(int Id);
        public Task<List<Review>> FindReviewsById(int Id);
/*        public  Task<IActionResult> GetUserId();
*/        public Task<List<SelectListItem>> SelectListItems();


    }
}