using NoteApp.Model;
using NoteApp.Service;
using NoteApp.Utility.SessionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteApp.Controllers
{
    public class LoginController : MainController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LoginService.Login(loginModel);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    View(loginModel);
                }
            }

            return View(loginModel);
        }

        public ActionResult Logout()
        {
            try
            {
                SessionUtility.Logout();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}