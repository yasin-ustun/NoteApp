using NoteApp.DAL.Entity;
using NPoco;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DAL
{
    public class DbOperations
    {
        private static Database Database
        {
            get
            {
                return new Database("NoteApp");
            }
        }

        public static void SaveUser(UserEntity userEntity)
        {
            if (userEntity != null)
            {
                using (var db = Database)
                {
                    db.Save<UserEntity>(userEntity);
                }
            }
        }

        public static NotesEntity GetNoteById(int noteId, bool? param = null)
        {
            using (var db = Database)
            {
                var query = db.Query<NotesEntity>()
                    .Include(x => x.CategoryEntity)
                    .Where(x => x.NoteId == noteId);


                if (param.HasValue)
                {
                    query.Where(x => x.IsPublished);
                }

                return query
                    .ToList()
                    .FirstOrDefault();
            }
        }

        public static UserEntity GetUser(string mail, string password)
        {
            using (var db = Database)
            {
                var sql = Sql.Builder;

                sql.Where("Mail = @0", mail);
                sql.Where("Password = @0", password);
                sql.Where("IsActive = @0", true);

                return db.SingleOrDefault<UserEntity>(sql);
            }
        }

        public static void SaveNote(NotesEntity noteEntity)
        {
            using (var db = Database)
            {
                db.Save<NotesEntity>(noteEntity);
            }
        }

        public static List<NotesEntity> GetNotes(int userId)
        {
            using (var db = Database)
            {
                return db.Query<NotesEntity>()
                    .Include(x => x.CategoryEntity)
                    .Include(x => x.CategoryEntity.UserEntity)
                    .Where(x => x.CategoryEntity.UserEntity.UserId == userId)
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.Subject)
                    .ToList();
            }
        }

        public static UserEntity GetUserByUserId(int userId)
        {
            using (var db = Database)
            {
                return db.SingleOrDefaultById<UserEntity>(userId);
            }
        }

        public static CategoryEntity GetCategoryById(int categoryId)
        {
            using (var db = Database)
            {
                return db.Query<CategoryEntity>()
                    .Include(x => x.UserEntity)
                    .Where(x => x.CategoryId == categoryId)
                    .ToList()
                    .FirstOrDefault();
            }
        }

        public static List<NotesEntity> GetNotesByCategoryId(int categoryId)
        {
            using (var db = Database)
            {
                return db.Query<NotesEntity>()
                    .Include(x => x.CategoryEntity)
                    .Where(x => x.CategoryEntity.CategoryId == categoryId)
                    .ToList();
            }
        }

        public static CategoryEntity GetCategory(int userId, string categoryName)
        {
            using (var db = Database)
            {
                var sql = Sql.Builder;

                sql.Where("UserId = @0", userId);
                sql.Where("CategoryName = @0", categoryName);

                return db.FirstOrDefault<CategoryEntity>(sql);
            }
        }

        public static UserEntity GetUserByMailAddress(string mail)
        {
            using (var db = Database)
            {
                return db.SingleOrDefault<UserEntity>("Where Mail = @0", mail);
            }
        }

        public static UserEntity GetUserByPassword(string password)
        {
            using (var db = Database)
            {
                return db.SingleOrDefault<UserEntity>("Where Password = @0", password);
            }
        }

        public static void SaveCategory(CategoryEntity categoryEntity)
        {
            if (categoryEntity != null)
            {
                using (var db = Database)
                {
                    db.Save<CategoryEntity>(categoryEntity);
                }
            }
        }

        public static List<CategoryEntity> GetCategories(int userId)
        {
            using (var db = Database)
            {
                return db.Query<CategoryEntity>()
                    .Include(x => x.UserEntity)
                    .Where(x => x.UserEntity.UserId == userId)
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.CategoryName)
                    .ToList();
            }
        }
    }
}
