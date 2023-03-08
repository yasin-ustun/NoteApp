using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Model
{
    public class UserPasswordModel
    {
        [Required]
        [DisplayName("e-Posta")]
        public string Mail { get; set; }

        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Şifre (Tekrar)")]
        public string PasswordAgain { get; set; }
    }
}
