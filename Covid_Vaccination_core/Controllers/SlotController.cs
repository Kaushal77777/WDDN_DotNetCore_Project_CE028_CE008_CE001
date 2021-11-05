using Covid_Vaccination_core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_Vaccination_core.Controllers
{
    public class SlotController : Controller
    {

        private readonly ISlotRepository _slotRepo;
        private readonly IUserRepository _userRepo;
        public SlotController(ISlotRepository slotRepo,IUserRepository userRepo)
        {
            _slotRepo = slotRepo;
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Book()
        {
            var phoneno = HttpContext.Session.GetString("phoneno");
            var password = HttpContext.Session.GetString("password");
            User user = _userRepo.GetUser(phoneno, password);
            ViewBag.user = user;
            return View();
        }

        [HttpPost]
        public IActionResult Book(Slot slot)
        {
            var phoneno = HttpContext.Session.GetString("phoneno");
            var password = HttpContext.Session.GetString("password");
            slot.User = _userRepo.GetUser(phoneno, password);
            slot.status = "Booked";
            if(slot.User != null)
            {
                if (ModelState.IsValid)
                {
                    Slot newSlot = _slotRepo.Add(slot);
                    return RedirectToAction(actionName: "Check", controllerName: "Slot");
                }
            }
            else
            {
                return RedirectToAction(actionName: "Login", controllerName: "User");
            }
            ViewBag.user = slot.User;
            return View();
        }

        [HttpGet]
        public IActionResult Check()
        {
            var phoneno = HttpContext.Session.GetString("phoneno");
            var password = HttpContext.Session.GetString("password");
            User user = _userRepo.GetUser(phoneno, password);
            if(user != null)
            {
                ViewBag.user = user;
                Slot slot = _slotRepo.GetSlot(user);
                if(slot != null)
                {
                    ViewBag.status = "Booked";
                }
                else
                {
                    ViewBag.status = "Pending";
                }                
            }
            return View();
        }
    }
}
