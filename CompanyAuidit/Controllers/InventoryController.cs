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
        private readonly AccessContext _context;
        public InventoryController(AccessContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SaveInventory()
        {
            return View(new InventoryViewModel());
        }


        [HttpPost]
        public IActionResult SaveInventory(InventoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Inventory inventory = new Inventory()
                {
                    Name = model.Name,
                   Status =model.Status,
                   Cost = model.Cost
                   
                };

                _context.Inventories.Add(inventory);
                _context.SaveChanges();
            }
            return View();
        }

    }

}