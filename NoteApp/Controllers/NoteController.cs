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
    public class NoteController : MainController
    {
        // GET: Note
        public ActionResult Index()
        {
            if (DoesSessionAbandon)
            {
                return RedirectToAction("Index", "Login");
            }
            var categories = CategoryService.GetCategoris();

            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

            return View();
        }

        public ActionResult UpdateNote(string p)
        {
            try
            {
                var noteId = Convert.ToInt32(Decode(p));

                var noteModel = NoteService.GetNoteModelById(noteId);

                var categories = CategoryService.GetCategoris();

                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

                return View("Index", noteModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult SaveNote(NoteModel noteModel)
        {
            try
            {
                if (string.IsNullOrEmpty(noteModel.Subject))
                {
                    throw new ValidationException("Konu başlığı giriniz!");
                }

                if (string.IsNullOrEmpty(noteModel.Note))
                {
                    throw new ValidationException("İçerik giriniz!");
                }

                NoteService.SaveNote(noteModel);

                var categories = CategoryService.GetCategoris();


                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

            }
            catch (ValidationException vex)
            {
                return Json(new
                {
                    success = false,
                    message = "Uyarı : " + vex.Message,
                    content = string.Empty
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Hata : " + ex.Message,
                    content = string.Empty
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                success = true,
                message = string.Empty,
                content = "Notunuz başarılı bir şekilde kaydedildi."
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NoteInfo(string NoteId)
        {
            try
            {
                var strsplit = Decode(NoteId).Split('|');

                var strnoteId = strsplit[0];

                bool? p = null;

                if(strsplit.Length == 2)
                {
                    p = false;

                    if (strsplit[1] == "1")
                    {
                        p = true;
                    }

                    ViewBag.Param = true;
                }

                var noteId = Convert.ToInt32(strnoteId);

                var note = NoteService.GetNoteModelById(noteId, p);

                ViewBag.Title = note.Subject;

                

                return View(note);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult DeleteNote(string NoteId)
        {
            try
            {
                var noteId = Convert.ToInt32(Decode(NoteId));

                NoteService.DeleteNote(noteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ShareNote(int noteId, bool value)
        {
            try
            {
                NoteService.ShareNote(noteId, value);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(new
            {
                success = true,
                message = string.Empty,
                content = "Yuppiii"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}