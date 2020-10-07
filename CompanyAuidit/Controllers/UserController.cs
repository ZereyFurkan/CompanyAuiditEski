using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAuidit.Entities;
using CompanyAuidit.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAuidit.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SaveUser()
        {
            return View(new SaveUserViewModel());
        }

        [HttpPost]
        public IActionResult SaveUser(User users)
        {
            return View();
        }
    }
}
