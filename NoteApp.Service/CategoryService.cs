using NoteApp.DAL;
using NoteApp.DAL.Entity;
using NoteApp.Model;
using NoteApp.Utility.SessionUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Service
{
    public class CategoryService
    {
        public static void SaveCategory(CategoryModel categoryModel)
        {
            var userEntity = UserService.GetUserByUserId(SessionPackage.UserId);

            if(userEntity == null)
            {
                throw new ValidationException("Lütfen Giriş yapıp tekrar deneyiniz!");
            }

            var categoryEntity = GetCategory(userEntity.UserId, categoryModel.CategoryName);

            if(categoryEntity != null)
            {
                if(categoryModel.CategoryId != categoryEntity.CategoryId)
                {
                    throw new ValidationException("Aynı isimde kategoriniz bulunmaktadır!");
                }
            }

            categoryEntity = GetCategoryById(categoryModel.CategoryId);

            if(categoryEntity == null)
            {
                categoryEntity = new CategoryEntity();
                categoryEntity.FillInsertDefaultValues();
            }
            else
            {
                categoryEntity.FillUpdateDefaultValues();
            }
            
            categoryEntity.CategoryName = categoryModel.CategoryName;
            categoryEntity.IsActive = true;
            categoryEntity.UserEntity = userEntity;

            DbOperations.SaveCategory(categoryEntity);
        }

        public static void DeleteCategory(int categoryId)
        {
            var categoryEntity = GetCategoryById(categoryId);

            if(categoryEntity != null)
            {
                categoryEntity.IsActive = false;
                categoryEntity.FillUpdateDefaultValues();
                DbOperations.SaveCategory(categoryEntity);

                NoteService.DeleteNoteByCategoryId(categoryId);
            }
        }

        internal static CategoryEntity GetCategoryById(int? categoryId)
        {
            if(!categoryId.HasValue)
            {
                throw new ValidationException("Kategori Bulunamadı");
            }

            return DbOperations.GetCategoryById(categoryId.Value);
        }

        public static CategoryModel GetCategoryModelById(int categoryId)
        {
            var categoryEntity = DbOperations.GetCategoryById(categoryId);

            var categoryModel = new CategoryModel
            {
                CategoryId = categoryEntity.CategoryId,
                CategoryName = categoryEntity.CategoryName
            };

            return categoryModel;
        }

        public static List<CategoryModel> GetCategoris()
        {
            var categories = DbOperations.GetCategories(SessionPackage.UserId);

            var categoryList = new List<CategoryModel>();

            foreach (var item in categories)
            {
                var category = new CategoryModel();

                category.CategoryId = item.CategoryId;
                category.CategoryName = item.CategoryName;

                categoryList.Add(category);
            }

            return categoryList;
        }

        public static CategoryEntity GetCategory(int userId, string categoryName)
        {
            return DbOperations.GetCategory(userId, categoryName);
        }
    }
}
