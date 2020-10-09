using System.Collections.Generic;
using CompanyAuidit.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyAuidit.Models
{
    public class SaveInventoryViewModel
    {
        public Inventory inventories { get; set; }
    }
}