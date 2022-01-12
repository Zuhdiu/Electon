using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Sale { get; set; }
        public int Bought { get; set; }
        public DateTime AddedDate { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public SelectListItem Categories { get; set; }
        [Required]
        public IFormFile DefaultPhoto { get; set; }
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
