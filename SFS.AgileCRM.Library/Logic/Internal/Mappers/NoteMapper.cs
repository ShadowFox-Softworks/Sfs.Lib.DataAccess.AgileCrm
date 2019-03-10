namespace SFS.AgileCRM.Library.Logic.Internal.Mappers
{
    using SFS.AgileCRM.Library.Entities.Notes;

    /// <summary>
    /// The Note Mapper.
    /// </summary>
    internal static class NoteMapper
    {
        /// <summary>
        /// Maps a AgileCRM domain model onto a AgileCRM entity model.
        /// </summary>
        /// <param name="agileCrmNoteModel">The AgileCRM note model.</param>
        /// <returns>
        ///   <see cref="AgileCrmContactNoteEntity" />.
        /// </returns>
        public static AgileCrmContactNoteEntity ToContactNoteEntity(this AgileCrmNoteModel agileCrmNoteModel)
        {
            var agileCrmServerNoteEntity = new AgileCrmContactNoteEntity
            {
                // Id = (retrieved only).
                // ContactId = (set in method only).
                Subject = agileCrmNoteModel.Subject,
                Description = agileCrmNoteModel.Description
            };

            return agileCrmServerNoteEntity;
        }

        /// <summary>
        /// Maps a AgileCRM domain model onto a AgileCRM entity model.
        /// </summary>
        /// <param name="agileCrmNoteModel">The AgileCRM note model.</param>
        /// <returns>
        ///   <see cref="AgileCrmDealNoteEntity" />.
        /// </returns>
        public static AgileCrmDealNoteEntity ToDealNoteEntity(this AgileCrmNoteModel agileCrmNoteModel)
        {
            var agileCrmServerNoteEntity = new AgileCrmDealNoteEntity
            {
                // Id = (retrieved only).
                // DealId = (set in method only).
                Subject = agileCrmNoteModel.Subject,
                Description = agileCrmNoteModel.Description
            };

            return agileCrmServerNoteEntity;
        }
    }
}