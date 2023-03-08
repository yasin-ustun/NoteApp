namespace NoteApp.DAL.Enumerations
{
    /// <summary>
    /// Kullanıcı Onaylanma durumu
    /// </summary>
    public enum ApprovalStatus : short
    {
        /// <summary>
        /// Onaylanmadı
        /// </summary>
        NotApproved = 0,

        /// <summary>
        /// Onaylandı
        /// </summary>
        Approved = 1
    }
}
