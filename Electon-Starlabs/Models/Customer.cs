using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electon_Starlabs.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public bool Locked { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address{ get; set; }
        public List<Order> Orders { get; set; }
    }
}
