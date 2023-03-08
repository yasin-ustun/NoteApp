using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Model
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        [DisplayName("Ad")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        [Required]
        public string SurName { get; set; }
        public string FullName 
        { 
            get
            {
                return Name + " " + SurName;
            }
        }

        [DisplayName("e-Posta Adresi")]
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [DisplayName("Şifre")]
        [Required]
        public string Password { get; set; }
    }
}
