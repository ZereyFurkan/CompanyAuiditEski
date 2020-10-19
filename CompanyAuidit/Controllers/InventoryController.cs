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
            var inventories = _context.Inventories.ToList();
            var model = new InventoryViewModel
            {
                Inventories = inventories
            };

            return View(model);
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
                    Status = model.Status,
                    Cost = model.Cost
                   
                };

                _context.Inventories.Add(inventory);
                
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(SaveInventory));
        }

        [HttpPost]
        public IActionResult SaveInventory2(InventoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Inventory inventory = new Inventory()
                {
                    Name = model.Name,
                    Status = model.Status,
                    Cost = model.Cost

                };

                _context.Inventories.Add(inventory);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(InventoryList));
        }

        public IActionResult InventoryList()
        {
            var users = _context.Users.ToList();
            var items = _context.Inventories.ToList();

            var result = new RelationListViewModel
            {
                Inventory = items,
                Users = users       
            };

            return View(result);
        }

        public IActionResult InventoryDelete(int id)
        {

            var result = _context.Inventories.FirstOrDefault(x => x.Id == id);
            _context.Inventories.Remove(result);


            var inventories = _context.UserAndInventoriyRelationship.Where(x => x.InventoriyId == id).ToList();
   
             _context.UserAndInventoriyRelationship.RemoveRange(inventories);
             _context.SaveChanges();
           
            return RedirectToAction(nameof(InventoryList));
        }

        [HttpPost]
        public IActionResult UpdateInventory(InventoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var inventory = new Inventory()
                {
                    Name = model.Name,
                    Status = model.Status,
                    Cost = model.Cost,
                    Id = model.Id

                };
                TempData["InventoryMessage"] = @$"Eşya {inventory.Name} güncellendi";
                _context.Inventories.Update
                    (inventory);
                _context.SaveChanges();
            }
            //return View();
            return RedirectToAction(nameof(InventoryList));
        }

        [HttpGet]
        public IActionResult UpdateInventory(int id)
        {
            var result = _context.Inventories.FirstOrDefault(x => x.Id == id);
            var inventory = new InventoryViewModel();
            if (ModelState.IsValid)
            {
                inventory.Id = result.Id;
                inventory.Name = result.Name;
                inventory.Status = result.Status;
                inventory.Cost = result.Cost;
            }
            return View(inventory);
        }

    }

}