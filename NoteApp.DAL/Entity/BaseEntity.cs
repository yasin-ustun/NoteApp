using NoteApp.Utility.SessionUtility;
using System;

namespace NoteApp.DAL.Entity
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? ModifyUserId { get; set; }
        public DateTime? ModifyDate { get; set; }

        public void FillInsertDefaultValues()
        {
            this.IsActive = true;
            this.CreateUserId = SessionPackage.UserId;
            this.CreateDate = DateTime.Now;
        }

        public void FillUpdateDefaultValues()
        {
            this.ModifyUserId = SessionPackage.UserId;
            this.ModifyDate = DateTime.Now;
        }
    }
}
