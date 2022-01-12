using Electon_Starlabs.Models;
using Electon_Starlabs.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTesting.Helper
{
    public static class CategoryHelper
    {
        public static Category CategoryData()
        {
            Byte[] bytes = new Byte[28];


            Category category = new Category
            {
                Id = 111,
                Name = "CVM",
                Description = "cvm testing units",
                Picture = bytes
            };
            return category;
        }

        public static CategoryViewModel CategoryViewModelData()
        {
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                Id = 111,
                Name = "CVM",
                Description = "cvm testing units",
                Photo = file
            };
            return categoryViewModel;
        }
    }
}
