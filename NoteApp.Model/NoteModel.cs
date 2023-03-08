using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Model
{
    public class NoteModel
    {
        public int NoteId { get; set; }

        [Required]
        [DisplayName("Konu Başlığı")]
        public string Subject { get; set; }

        [Required]
        [DisplayName("İçerik")]
        public string Note { get; set; }
        
        [Required]
        [DisplayName("Kategori")]
        public int? CategoryId { get; set; }

        public CategoryModel CategoryModel { get; set; }

        public bool IsPublished { get; set; }
    }
}
