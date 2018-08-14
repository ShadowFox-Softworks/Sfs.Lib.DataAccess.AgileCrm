namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Resolvers.Requests
{
    using System;
    using Entity;
    using Entity.Internal.Requests;

    /// <summary>
    /// The Deal Request Entity Resolver
    /// </summary>
    internal static class DealRequestEntityResolver
    {
        /// <summary>
        /// Resolves the argument entity to a AgileCRM request entity.
        /// </summary>
        /// <param name="dealEntity">The deal entity.</param>
        /// <returns>
        ///   <see cref="DealRequestEntity" />
        /// </returns>
        public static DealRequestEntity ResolveToCrmRequest(this AgileCrmDealEntity dealEntity)
        {
            throw new NotImplementedException();
        }
    }
}