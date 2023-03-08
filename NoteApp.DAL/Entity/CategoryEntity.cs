using NPoco;

namespace NoteApp.DAL.Entity
{
    [TableName("Categories")]
    [PrimaryKey("CategoryId")]
    public class CategoryEntity : BaseEntity
    {
        public int CategoryId { get; set; }

        [Reference(ReferenceType.Foreign, ColumnName = "UserId", ReferenceMemberName = "UserId")]
        public UserEntity UserEntity { get; set; }
        
        public string CategoryName { get; set; }
    }
}
