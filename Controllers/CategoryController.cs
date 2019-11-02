using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sludinajumi.Logic;
using SludinajumuPortals.Models;

namespace SludinajumuPortals.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index(int id)
        {
            var manager = new ItemManager();
            manager.Seed();
            var cat_manager = new CategoryManager();
            cat_manager.Seed();
            var items = manager.GetByCategory(id);
            var categories1 = cat_manager.GetAll();
            foreach (var cat in categories1)
            {
                //atlasa un uzstada prechu skaitu zem konkretas kategoijas
            };
            var model = new CatalogModel()
            {
                Items = items,
                categories = categories1
            };

            return View(model);
        }
        //1.pievieno jaunu darbību buy ar parametru id
        //2.atlasa lietotaj grozu no sesijas
        //2.1 ja grozs nav definets, definee jaunu sarakstu new list<int>())
        //3.pievieno izveleto preces id lietotaja grozam
        //4.saglaba lietotaja grozu sesijaa
        public IActionResult Buy(int id)
        {
            var manager = new ItemManager();
            manager.Seed();
            var item = manager.Get(id);
            var basket = HttpContext.Session.GetUserBasket();

            if (basket == null)
            {
                basket = new List<int>();
            }
            basket.Add(id);
            HttpContext.Session.SetUserBasket(basket);
            return RedirectToAction("Index", "Item", new { id = item.CategoryId });
        }
        public IActionResult Delete(int id)
        {
            var basket = HttpContext.Session.GetUserBasket();

            basket.Remove(id);
            HttpContext.Session.SetUserBasket(basket);
            return RedirectToAction("Basket");
        }
        public IActionResult Basket()
        {
            //1.define jaunu sarakstu preceem
            //2.par katru preci, kas ir lietotaja sesijaa, atlasa taas datus un pievieno sarakstam
            //3.atgriez precu sarakstu ar view
            List<Item> items = new List<Item>();
            List<int> basket = HttpContext.Session.GetUserBasket();
            if (basket != null)
            {
                var manager = new ItemManager();
                manager.Seed();

                foreach (var id in basket)
                {
                    items.Add(manager.Get(id));
                }
            }
            return View(items);

        }
        public IActionResult JaunsSludinajums()
        {
            JaunsSludinajumsModel model = new JaunsSludinajumsModel();
            CategoryManager categoryManager = new CategoryManager();
            categoryManager.Seed();
            model.Email = HttpContext.Session.GetUserEmail();
                model.categories = categoryManager.GetAll();

            return View(model);
        }
        [HttpPost]
        public IActionResult JaunsSludinajums(JaunsSludinajumsModel model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}