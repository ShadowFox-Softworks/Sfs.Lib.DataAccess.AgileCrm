namespace SFS.AgileCRM.Library.Logic.Internal.Mappers
{
    using System;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;

    /// <summary>
    /// The Task Mapper.
    /// </summary>
    internal static class TaskMapper
    {
        /// <summary>
        /// Maps a AgileCrmTaskEntity onto a TaskEntityBase.
        /// </summary>
        /// <param name="agileCrmTaskModel">The AgileCRM task model.</param>
        /// <returns>
        ///   <see cref="AgileCrmTaskEntity"/>.
        /// </returns>
        public static AgileCrmTaskEntity ToTaskEntityBase(this AgileCrmTaskRequest agileCrmTaskModel)
        {
            throw new NotImplementedException();
        }
    }
}