namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Resolvers.Responses
{
    using System;
    using Osw.Lib.DataAccess.AgileCrm.Entities;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Responses;

    /// <summary>
    /// The Deal Response Entity Resolver
    /// </summary>
    internal static class DealResponseEntityResolver
    {
        /// <summary>
        /// Resolves the argument entity to a AgileCRM request entity.
        /// </summary>
        /// <param name="dealEntity">The deal entity.</param>
        /// <returns>
        ///   <see cref="AgileCrmDealEntity" />
        /// </returns>
        public static AgileCrmDealEntity ResolveFromCrmResponse(this DealResponseEntity dealEntity)
        {
            throw new NotImplementedException();
        }
    }
}