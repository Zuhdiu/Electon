using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.ViewModels
{
    public class ProductReviewViewModel
    {
        public string Title { get; set; }
        public List<Review> ListOfComments{ get; set; }
        public string  Comment { get; set; }
        public int  ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
