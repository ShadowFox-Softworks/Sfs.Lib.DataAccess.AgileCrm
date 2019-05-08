namespace SFS.AgileCRM.Library.Logic.Internal.Mappers
{
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;

    /// <summary>
    /// The Note Mapper.
    /// </summary>
    internal static class NoteMapper
    {
        /// <summary>
        /// Maps a AgileCrmContactNoteModel onto a ContactNoteEntityBase.
        /// </summary>
        /// <param name="agileCrmNoteModel">The AgileCRM note model.</param>
        /// <returns>
        ///   <see cref="AgileCrmContactNoteEntity" />.
        /// </returns>
        public static AgileCrmContactNoteEntity ToContactNoteEntityBase(this AgileCrmNoteRequest agileCrmNoteModel)
        {
            var agileCrmServerNoteEntity = new AgileCrmContactNoteEntity
            {
                // Id = (set by calling method if required).
                // ContactId = (set by calling method if required).
                Subject = agileCrmNoteModel.Subject,
                Description = agileCrmNoteModel.Description
            };

            return agileCrmServerNoteEntity;
        }

        /// <summary>
        /// Maps a AgileCrmDealNoteModel onto a DealNoteEntityBase.
        /// </summary>
        /// <param name="agileCrmNoteModel">The AgileCRM note model.</param>
        /// <returns>
        ///   <see cref="AgileCrmDealNoteEntity" />.
        /// </returns>
        public static AgileCrmDealNoteEntity ToDealNoteEntityBase(this AgileCrmNoteRequest agileCrmNoteModel)
        {
            var agileCrmServerNoteEntity = new AgileCrmDealNoteEntity
            {
                // Id = (set by calling method if required).
                // DealId = (set by calling method if required).
                Subject = agileCrmNoteModel.Subject,
                Description = agileCrmNoteModel.Description
            };

            return agileCrmServerNoteEntity;
        }
    }
}