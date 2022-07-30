using firstMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace firstMVC.Controllers
{
    public class HomeController : Controller
    {
        NewsContext db;
        public HomeController(NewsContext context)
        {
            db = context; 
        }
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            var categories= db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveContact(ContactUs model)
        {
            db.Contacts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Messages()
        {
            
            return View(db.Contacts.ToList());
        }

        public IActionResult News(int id)
        {
            Category c = db.Categories.Find(id);
            ViewBag.cat = c.Name;
            var news= db.News.Where(x => x.CategoryId == id).OrderByDescending(x=>x.Date).ToList();
            return View(news);
        }

        public IActionResult DeleteNews(int id)
        {
            var news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
