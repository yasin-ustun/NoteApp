using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Model
{
    public class LoginModel
    {
        [DisplayName("Kullanıcı Adı")]
        [Required]
        public string Mail { get; set; }

        [DisplayName("Şifre")]
        [Required]
        public string Password { get; set; }
    }
}
