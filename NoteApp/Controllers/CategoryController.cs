using NoteApp.Model;
using NoteApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteApp.Controllers
{
    public class CategoryController : MainController
    {
        // GET: Category
        public ActionResult Index()
        {
            if (DoesSessionAbandon)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.Categories = CategoryService.GetCategoris();

            return View();
        }

        [HttpPost]
        public ActionResult Index(CategoryModel categoryModel)
        {
            try
            {
                if (string.IsNullOrEmpty(categoryModel.CategoryName))
                {
                    throw new ValidationException("Kategori Giriniz!");
                }
                CategoryService.SaveCategory(categoryModel);

                ViewBag.Categories = CategoryService.GetCategoris();
            }
            catch (ValidationException vex)
            {
                ViewBag.ErrorMessage = vex.Message;
            }
            catch (Exception ex)
            {

            }

            return View(categoryModel);
        }

        public ActionResult DeleteCategory(int CategoryId)
        {
            try
            {
                CategoryService.DeleteCategory(CategoryId);

                ViewBag.Categories = CategoryService.GetCategoris();
            }
            catch (Exception ex)
            {

                throw;
            }

            return View("Index");
        }
    }
}