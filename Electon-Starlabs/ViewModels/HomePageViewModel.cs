using Electon_Starlabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.ViewModels
{
    public class HomePageViewModel
    {
        public List<CategoryProducts> CategoryProducts { get; set; }
    }
    public class CategoryProducts
    {
        public Category Category { get; set; }
        public List<Product> products { get; set; }
    };
}
