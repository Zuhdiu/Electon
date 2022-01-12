using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTesting.Helper
{
    public static class ProductHelper
    {
        public static ProductViewModel ProductViewModelData()
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
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Id = 1,
                Name = "Product",
                Description = "Description",
                Price = 1299,
                Quantity = 100,
                Sale = 0,
                Bought = 0,
                CategoryId = 1,
                AddedDate = DateTime.Now,
                Brand = "Brand",
                DefaultPhoto = file,
                Images = files
            };

            return productViewModel;
        }

        public static Product ProductData()
        {
            byte[] byteArray = new byte[28];
            Product product = new Product
            {
                Id = 1,
                Name = "Product",
                Description = "Description",
                Price = 1299,
                Quantity = 100,
                Sale = 0,
                Bought = 0,
                AddedDate = DateTime.Now,
                Brand = "Brand",
                CategoryId = 1,
                DefaultImage = byteArray
            };

            return product;
        }

        public static List<Product> ProductListData()
        {
            List<Product> products = new List<Product>();
            for(int i = 0; i<5; i++)
            {
                Product product = ProductData();
                product.Id = i;
                products.Add(product);
            }
            return products;
        }
    }
}
