//using NoteApp.DAL.Entity;
using NoteApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NoteApp.Utility.SessionUtility
{
    public class SessionUtility
    {
        public static void SetSessionPackage(UserModel userModel)
        {
            SessionPackage.UserId = userModel.UserId;
            SessionPackage.UserName = userModel.UserName;
            SessionPackage.FullName = userModel.FullName;
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}
