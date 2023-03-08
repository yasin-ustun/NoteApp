using NPoco;

namespace NoteApp.DAL.Entity
{
    public class ImagesEntity : BaseEntity
    {
        public int ImageId { get; set; }

        [Reference(ReferenceType.Foreign, ColumnName = "NoteId", ReferenceMemberName = "NoteId")]
        public NotesEntity NotesEntity { get; set; }

        public string ImageName { get; set; }
    }
}
