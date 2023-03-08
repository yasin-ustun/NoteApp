using NPoco;

namespace NoteApp.DAL.Entity
{
    [TableName("Notes")]
    [PrimaryKey("NoteId")]
    public class NotesEntity : BaseEntity
    {
        public int NoteId { get; set; }

        [Reference(ReferenceType.Foreign, ColumnName = "CategoryId", ReferenceMemberName = "CategoryId")]
        public CategoryEntity CategoryEntity { get; set; }

        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
    }
}
