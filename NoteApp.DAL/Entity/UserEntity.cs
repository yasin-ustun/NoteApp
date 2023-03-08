using NPoco;

namespace NoteApp.DAL.Entity
{
    [TableName("Users")]
    [PrimaryKey("UserId")]
    public class UserEntity : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
    }
}
