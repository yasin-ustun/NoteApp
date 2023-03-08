using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Model
{
    public class CategoryModel
    {
        
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
    }
}
