using NoteApp.DAL;
using NoteApp.DAL.Entity;
using NoteApp.Model;
using NoteApp.Utility.SessionUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Service
{
    public class NoteService
    {
        public static void SaveNote(NoteModel noteModel)
        {
            var categoryEntity = CategoryService.GetCategoryById(noteModel.CategoryId);

            var noteEntity = DbOperations.GetNoteById(noteModel.NoteId);

            if (noteEntity == null)
            {
                noteEntity = new NotesEntity();
                noteEntity.IsPublished = false;
                noteEntity.FillInsertDefaultValues();
            }
            else
            {
                noteEntity.FillUpdateDefaultValues();
            }

            noteEntity.Content = noteModel.Note;
            noteEntity.Subject = noteModel.Subject;
            noteEntity.IsActive = true;
            noteEntity.CategoryEntity = categoryEntity;

            DbOperations.SaveNote(noteEntity);
        }

        public static NoteModel GetNoteModelById(int noteId, bool? param = null)
        {
            var noteEntity = DbOperations.GetNoteById(noteId, param);

            var noteModel = new NoteModel();

            if (noteEntity != null)
            {
                noteModel.NoteId = noteEntity.NoteId;
                noteModel.Subject = noteEntity.Subject;
                noteModel.Note = noteEntity.Content;
                noteModel.CategoryId = noteEntity.CategoryEntity.CategoryId;
                noteModel.CategoryModel = CategoryService.GetCategoryModelById(noteModel.CategoryId.Value);
                noteModel.IsPublished = noteEntity.IsPublished;
            }

            return noteModel;
        }

        public static List<NoteModel> GetNotes()
        {
            var noteEntities = DbOperations.GetNotes(SessionPackage.UserId);

            var notes = new List<NoteModel>();

            foreach (var item in noteEntities)
            {
                var note = new NoteModel
                {
                    NoteId = item.NoteId,
                    Subject = item.Subject,
                    Note = item.Content,
                    IsPublished = item.IsPublished,
                    CategoryId = item.CategoryEntity.CategoryId
                };

                notes.Add(note);
            }

            return notes;
        }

        internal static void DeleteNoteByCategoryId(int categoryId)
        {
            var noteEntities = DbOperations.GetNotesByCategoryId(categoryId);

            foreach (var note in noteEntities)
            {
                note.IsActive = false;
                note.FillUpdateDefaultValues();

                DbOperations.SaveNote(note);
            }
        }

        public static void DeleteNote(int noteId)
        {
            var noteEntity = DbOperations.GetNoteById(noteId);

            noteEntity.IsActive = false;
            noteEntity.FillUpdateDefaultValues();

            DbOperations.SaveNote(noteEntity);
        }

        public static void ShareNote(int noteId, bool value)
        {
            var noteEntity = DbOperations.GetNoteById(noteId);

            noteEntity.IsPublished = value;
            noteEntity.FillUpdateDefaultValues();

            DbOperations.SaveNote(noteEntity);
        }
    }
}
