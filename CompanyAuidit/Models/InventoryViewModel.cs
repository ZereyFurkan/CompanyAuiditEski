using System.Collections.Generic;
using CompanyAuidit.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyAuidit.Models
{
    public class InventoryViewModel
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
    }
}