using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CompanyAuidit.Contexts;
using CompanyAuidit.Entities;
using CompanyAuidit.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAuidit.Controllers
{
    public class UserController : Controller
    {
        private readonly AccessContext _context;
        public UserController(AccessContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SaveUser()
        {
            return View(new UserViewModel());
        }


        [HttpPost]
        public IActionResult SaveUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user=new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Department = model.Department,
                    Mission = model.Mission
                };

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(SaveUser));
        }

        public IActionResult UserList()
        {
            var result = _context.Users.ToList();
            return View(result);
        }

        public IActionResult UserDelete(int id)
        {

            var result = _context.Users.FirstOrDefault(x=>x.Id==id);
            _context.Users.Remove(result);


            var inventories = _context.UserAndInventoriyRelationship.Where(x => x.UserId == id).ToList();
            
            _context.UserAndInventoriyRelationship.RemoveRange(inventories);
            _context.SaveChanges();

            return RedirectToAction(nameof(UserList));
        }
    }
    
}
