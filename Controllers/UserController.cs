using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sludinajumi.Logic;
using SludinajumuPortals.Models;

namespace SludinajumuPortals.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Pieslegties()
        {
            return View();
        }
        public IActionResult Registreties()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Registreties(UserModel model)
        {
            if (ModelState.IsValid)
            {
                UserManager manager = new UserManager();
                if (manager.GetByEmail(model.Email) != null)
                {
                    ModelState.AddModelError("error", "šāds epasts jau eksistē");
                }
                else
                {
                    manager.Create(new Sludinajumi.Logic.User()
                    {
                        Email = model.Email,
                        Password = model.Password,
                    });
                    TempData["message"] = "account created";
                    return RedirectToAction("Pieslegties");
                }

            }
            return View();
        }
        [HttpPost]
        public IActionResult Pieslegties(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var manager = new UserManager();
                var user = manager.GetByEmailAndPassword(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("error2", "nepareizs epasts un/vai parole");
                }
                else
                {
                    HttpContext.Session.SetUserId(user.Id);
                    HttpContext.Session.SetUserEmail(user.Email);

                    TempData["message2"] = "Tu esi pieslēdzies";
                    return RedirectToAction("Index", "Category");
                }

            }
            return View();
        }
        public IActionResult Iziet()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Category");
            //item ir kontrolieris
        }
    }
}
