using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Microsoft.Ajax.Utilities;
using NoteApp.Utility.SessionUtility;

namespace NoteApp.Controllers
{
    public class MainController : Controller
    {
        public static bool DoesSessionAbandon => SessionPackage.UserId == 0;

        public static string Encode(string parameter)
        {
            var bytes = UTF8Encoding.UTF8.GetBytes(parameter);

            return Convert.ToBase64String(bytes);
        }

        public static string Decode(object parameter)
        {
            byte[] bytes = Convert.FromBase64String(parameter.ToString());

            return UTF8Encoding.UTF8.GetString(bytes);
        }
    }
}