using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAuidit.Contexts;
using CompanyAuidit.Entities;
using CompanyAuidit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyAuidit.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SaveInventory()
        {
            return View(new SaveInventoryViewModel());
        }

        [HttpPost]
        public IActionResult SaveInventory(Inventory inventories)
        {
            return View();
        }

        private readonly AccessContext _context;
        public InventoryController(AccessContext context)
        {
            _context = context;
        }

        //testtt
    }
}
