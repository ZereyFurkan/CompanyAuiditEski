using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAuidit.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAuidit.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccessContext _context;
        public HomeController(AccessContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var userslist = _context.Users.ToList();

            return View(userslist);
        }
    }
}