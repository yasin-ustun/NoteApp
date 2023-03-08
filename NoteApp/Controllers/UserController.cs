using NoteApp.Model;
using NoteApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteApp.Controllers
{
    public class UserController : MainController
    {
        // GET: User
        public ActionResult Index()
        {
            if (DoesSessionAbandon)
            {
                return View();
            }

            var user = UserService.GetSessionUser();

            return View(user);
        }

        [HttpPost]
        public ActionResult Index(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserService.SaveUser(userModel);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    throw ex;
                    //return Index(userModel);
                }
            }

            return View(userModel); // return LinkSendPAge()
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}