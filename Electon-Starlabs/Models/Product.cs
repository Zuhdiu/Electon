using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int Bought { get; set; }
        public int Quantity { get; set; }
        public int Sale { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public byte[] DefaultImage { get; set; }
        public DateTime AddedDate { get; set; }
        public int? HitCount { get; set; }
    }
}
