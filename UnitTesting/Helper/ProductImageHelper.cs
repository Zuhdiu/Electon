using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTesting.Helper
{
    public static class ProductImageHelper
    {
        public static ProductImage ProductImageData()
        {
            ProductImage productImage = new ProductImage
            {
                Id = 1,
                ProductId = 1,
                ProductImg = new byte[28]
            };
            return productImage;
        }
        public static ProductImageViewModel ProductImageViewModelData()
        {
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            List<IFormFile> files = new List<IFormFile>()
            {
                file,
                file,
                file
            };
            ProductImageViewModel productImageViewModel = new ProductImageViewModel()
            {
                ProductId = 1,
                Images = files
            };
            return productImageViewModel;
        }
    }
}
