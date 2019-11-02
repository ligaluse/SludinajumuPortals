using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sludinajumi.Logic;
using SludinajumuPortals.Models;

namespace SludinajumuPortals.Controllers
{
    public class AddController : Controller
    {
        public IActionResult Index(int id)
        {

            var manager = new ItemManager();
            manager.Seed();
            var items = manager.GetByCategory(id);
            return View(items);

        }
        public IActionResult Sludinajums(int id)
        {

            var manager = new ItemManager();
            manager.Seed();
            var Manager = new CategoryManager();
            Manager.Seed();
            var item = manager.Get(id);
            item.Category = Manager.Get(item.CategoryId);
            return View(item);
        }
       
    }
       
}