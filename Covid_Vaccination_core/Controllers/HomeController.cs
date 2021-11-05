using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Vaccination_core.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("phoneno");
            HttpContext.Session.Remove("password");
            return RedirectToAction(actionName: "Login", controllerName: "User");
        }
    }
}
