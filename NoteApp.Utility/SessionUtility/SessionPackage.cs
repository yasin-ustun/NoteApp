using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NoteApp.Utility.SessionUtility
{
    public class SessionPackage
    {
        public static int UserId
        {
            get
            {
                return Utility.Convert<int>(HttpContext.Current.Session["UserId"]);
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
        public static string UserName
        {
            get
            {
                return Utility.Convert<string>(HttpContext.Current.Session["UserName"]);
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }

        public static string FullName
        {
            get
            {
                return Utility.Convert<string>(HttpContext.Current.Session["FullName"]);
            }
            set
            {
                HttpContext.Current.Session["FullName"] = value;
            }
        }
    }
}
