using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

    }
    
}
