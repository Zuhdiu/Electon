using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.ViewModels
{
    public class ProductImageViewModel
    {
        public int ProductId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
