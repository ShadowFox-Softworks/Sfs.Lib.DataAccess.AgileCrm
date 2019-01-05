namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Mappers
{
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Notes;

    /// <summary>
    /// The Note Entity Mapper.
    /// </summary>
    internal static class NoteEntityMapper
    {
        /// <summary>
        /// Maps the AgileCRM client entity onto a AgileCRM server entity.
        /// </summary>
        /// <param name="agileCrmClientNoteEntity">The agile CRM client note entity.</param>
        /// <returns>
        ///   <see cref="AgileCrmServerContactNoteEntity" />.
        /// </returns>
        public static AgileCrmServerContactNoteEntity ToServerContactNoteEntity(this AgileCrmClientNoteEntity agileCrmClientNoteEntity)
        {
            var agileCrmServerNoteEntity = new AgileCrmServerContactNoteEntity
            {
                // AgileCrmServerContactNoteEntity.Id (retrieved only).
                // AgileCrmServerContactNoteEntity.ContactId (set in method only).
                Subject = agileCrmClientNoteEntity.Subject,
                Description = agileCrmClientNoteEntity.Description
            };

            return agileCrmServerNoteEntity;
        }

        /// <summary>
        /// Translates the AgileCRM client entity to a AgileCRM server entity.
        /// </summary>
        /// <param name="agileCrmClientNoteEntity">The agile CRM client note entity.</param>
        /// <returns>
        ///   <see cref="AgileCrmServerDealNoteEntity" />.
        /// </returns>
        public static AgileCrmServerDealNoteEntity ToServerDealNoteEntity(this AgileCrmClientNoteEntity agileCrmClientNoteEntity)
        {
            var agileCrmServerNoteEntity = new AgileCrmServerDealNoteEntity
            {
                // AgileCrmServerDealNoteEntity.Id (retrieved only).
                // AgileCrmServerDealNoteEntity.DealId (set in method only).
                Subject = agileCrmClientNoteEntity.Subject,
                Description = agileCrmClientNoteEntity.Description
            };

            return agileCrmServerNoteEntity;
        }
    }
}