using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAuidit.Contexts;
using CompanyAuidit.Entities;
using CompanyAuidit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CompanyAuidit.Controllers
{
    public class RelationController : Controller
    {
        private readonly AccessContext _context;

        public RelationController(AccessContext context)
        {
            _context = context;

        }


        public IActionResult Inventory(int id)
        {
            var inventories = (from user in _context.Users
                               where user.Id == id
                               join aratablo in _context.UserAndInventoriyRelationship on user.Id equals aratablo.UserId
                               join inventory in _context.Inventories on aratablo.InventoriyId equals inventory.Id
                               select inventory)
                                .ToList();

            var userr = _context.Users.FirstOrDefault(x => x.Id == id);

            var items = _context.Inventories.ToList();

            var model = new RelationListViewModel
            {
                Inventory = inventories,
                User = userr,
                Items = items
            };

            //var model = _context.Users.Where(x => x.Id == id).Include(x => x.UserAndInventoriyRelationships).ThenInclude(x => x.Item).ToList();

            return View(model);
        }

        public IActionResult InventoryDelete(int userId, int inventoriyId)
        {
            var result = _context.UserAndInventoriyRelationship.FirstOrDefault(x => x.UserId == userId && x.InventoriyId == inventoriyId);
            _context.UserAndInventoriyRelationship.Remove(result);
            _context.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        public IActionResult CreateItem(int userId, int itemId)
        {
            var result = new UserAndInventoriyRelationship { UserId = userId, InventoriyId = itemId };
            _context.UserAndInventoriyRelationship.Add(result);
            _context.SaveChanges();
            return RedirectToAction("Index", "User");
        }

    }
}