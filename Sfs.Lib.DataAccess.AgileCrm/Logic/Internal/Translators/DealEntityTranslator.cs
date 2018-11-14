namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Resolvers.Requests
{
    using System;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Deals;

    /// <summary>
    /// The Deal Entity Translator.
    /// </summary>
    internal static class DealEntityTranslator
    {
        /// <summary>
        /// Translates the AgileCRM client entity to a AgileCRM server entity.
        /// </summary>
        /// <param name="agileCrmClientDealEntity">The agile CRM client deal entity.</param>
        /// <returns>
        ///   <see cref="AgileCrmServerDealEntity" />.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public static AgileCrmServerDealEntity ToServerEntity(this AgileCrmClientDealEntity agileCrmClientDealEntity)
        {
            throw new NotImplementedException();
        }
    }
}