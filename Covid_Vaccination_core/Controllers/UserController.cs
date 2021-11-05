using Microsoft.AspNetCore.Mvc;
using Covid_Vaccination_core.Models;
using Covid_Vaccination_core.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Covid_Vaccination_core.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            var phoneno = HttpContext.Session.GetString("phoneno");
            var password = HttpContext.Session.GetString("password");
            User user = _userRepo.GetUser(phoneno, password);
            ViewBag.user = user;
            return View();
        }

        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                User newUser = _userRepo.Add(user);
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            ViewBag.user = user;
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            var phoneno = HttpContext.Session.GetString("phoneno");
            var password = HttpContext.Session.GetString("password");
            User user = _userRepo.GetUser(phoneno, password);
            ViewBag.user = user;
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                User u = _userRepo.GetUser(loginUser.Phoneno,loginUser.Password);
                if(u != null)
                {
                    HttpContext.Session.SetString("phoneno", loginUser.Phoneno);
                    HttpContext.Session.SetString("password", loginUser.Password);
                    return RedirectToAction(actionName: "Book", controllerName: "Slot");
                }
                else
                {
                    ModelState.AddModelError("Phoneno", "Invalid Credentials");
                    return View();
                }
                
            }
            return View();
        }
    }
}
