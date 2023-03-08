using NoteApp.Model;
using NoteApp.Utility.SessionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Service
{
    public class LoginService
    {
        public static void Login(LoginModel loginModel)
        {
            var userEntity = UserService.GetUser(loginModel.Mail, loginModel.Password);

            var userModel = new UserModel
            {
                UserId = userEntity.UserId,
                UserName = userEntity.UserName,
                Name = userEntity.Name,
                SurName = userEntity.SurName,
                Mail = userEntity.Mail
            };

            SessionUtility.SetSessionPackage(userModel);
        }
    }
}
