using NoteApp.Service;
using NoteApp.Utility.SessionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteApp.Controllers
{
    public class HomeController : MainController
    {
        public ActionResult Index()
        {
            if (DoesSessionAbandon)
            {
                return RedirectToAction("Index", "Login");
            }

            var notes = NoteService.GetNotes();

            //var categories = CategoryService.GetCategoris();
            //ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

            return View(notes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}