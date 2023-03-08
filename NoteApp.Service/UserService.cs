using NoteApp.DAL;
using NoteApp.DAL.Entity;
using NoteApp.Model;
using NoteApp.Utility.SessionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoteApp.Service
{
    public class UserService
    {
        public static void SaveUser(UserModel userModel)
        {
            var user = DbOperations.GetUserByMailAddress(userModel.Mail);

            var userEntity = new UserEntity();

            if (user != null)
            {
                userEntity = user;
                userEntity.FillUpdateDefaultValues();
            }
            else
            {
                userEntity.UserName = GenerateUserName(userModel);
                userEntity.Password = userModel.Password;
                //userEntity.Password = GenerateUniquePassword();

                userEntity.FillInsertDefaultValues();
            }

            userEntity.Name = userModel.Name;
            userEntity.SurName = userModel.SurName;
            userEntity.FullName = userModel.FullName;
            userEntity.IsActive = true;
            userEntity.Mail = userModel.Mail;
            
            DbOperations.SaveUser(userEntity);
        }

        internal static UserEntity GetUserByUserId(int userId)
        {
            return DbOperations.GetUserByUserId(userId);
        }

        private static string GenerateUniquePassword()
        {
            var md5 = new MD5CryptoServiceProvider();

            var guid = Guid.NewGuid();

            var bytes = Encoding.UTF8.GetBytes(guid.ToString());

            var data = md5.ComputeHash(bytes, 0, 10);

            var password = Convert.ToBase64String(data).Substring(0,10);

            if (PasswordExists(password))
            {
                return GenerateUniquePassword();
            }

            return password;
        }

        private static bool PasswordExists(string password)
        {
            var user = DbOperations.GetUserByPassword(password);

            return user != null;
        }

        private static string GenerateUserName(UserModel userModel)
        {
            var atIndex = userModel.Mail.IndexOf("@");

            var userName = userModel.Mail.Substring(0, atIndex);

            return userName;
        }

        public static UserEntity GetUser(string mail, string password)
        {
            var userEnitity = DbOperations.GetUser(mail, password);

            if(userEnitity == null)
            {
                throw new Exception("Kullanıcı Adı veya Şifre Hatalıdır! Kontrol edip tekrar giriş yapmayı deneyiniz!");
            }

            return userEnitity;
        }

        public static UserModel GetSessionUser()
        {
            var userEntity = GetUserByUserId(SessionPackage.UserId);

            var userModel = new UserModel
            {
                UserId = userEntity.UserId,
                UserName = userEntity.UserName,
                Name = userEntity.Name,
                SurName = userEntity.SurName,
                Mail = userEntity.Mail
            };

            return userModel;
        }
    }
}
