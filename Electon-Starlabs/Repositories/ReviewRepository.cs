using Electon_Starlabs.Contracts.Interfaces.Repositories;
using Electon_Starlabs.Data;
using Electon_Starlabs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Electon_Starlabs.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext context;
        public ReviewRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Review> Create(Review entity)
        {
            Console.WriteLine("asd");
            var c = context.Reviews.Add(entity);
            Console.WriteLine(c);
            await Save();
            return entity;

        }

        public async Task<bool> Delete(Review entity)
        {
            context.Reviews.Remove(entity);
            return await Save();
        }

        public async Task<Review> FindById(int Id)
        {
            return await context.Reviews.Include(x => x.Product).Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            int changes =  context.SaveChanges();
            return  changes > 0;
        }

        public async Task<List<SelectListItem>> SelectListItems()
        {
            List<SelectListItem> categories = await context.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToListAsync();
            return categories;
        }

        public async Task<bool> Update(Review entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await Save();
        }

        public async Task<List<Review>> FindAll()
        {
            
            return await context.Reviews.Include(x => x.Customer).ToListAsync();
        }

        public async Task<List<Review>> FindReviewsById(int Id)
        {
            var review = await context.Reviews.Include(x => x.Customer).Where(x => x.ProductId == Id).ToListAsync();
            return review;
        }

        /*public Task<IActionResult> GetUserId()
        {
            return;
        }*/
    }
}