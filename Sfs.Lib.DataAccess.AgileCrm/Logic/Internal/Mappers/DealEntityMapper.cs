namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Mappers
{
    using System.Collections.Generic;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Deals;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <summary>
    /// The Deal Entity Mapper.
    /// </summary>
    internal static class DealEntityMapper
    {
        /// <summary>
        /// Maps the AgileCRM client entity onto a AgileCRM server entity.
        /// </summary>
        /// <param name="agileCrmClientDealEntity">The agile CRM client deal entity.</param>
        /// <returns>
        ///   <see cref="AgileCrmServerDealEntity" />.
        /// </returns>
        public static AgileCrmServerDealEntity ToServerDealEntity(this AgileCrmClientDealEntity agileCrmClientDealEntity)
        {
            var agileCrmServerCustomDataEntities = new List<AgileCrmServerCustomDataEntity>();

            foreach (var item in agileCrmClientDealEntity.CustomFields)
            {
                agileCrmServerCustomDataEntities.Add(
                    new AgileCrmServerCustomDataEntity
                    {
                        Name = item.Key,
                        Value = item.Value
                    });
            }

            var agileCrmServerDealEntity = new AgileCrmServerDealEntity
            {
                // AgileCrmServerDealEntity.Id (set in method only).
                // AgileCrmServerDealEntity.TrackId (retrieved only).
                // AgileCrmServerDealEntity.ContactId (retrieved only).
                Name = agileCrmClientDealEntity.Name,
                CloseDate = agileCrmClientDealEntity.CloseDate.ToEpoch(),
                Milestone = agileCrmClientDealEntity.Milestone,
                Probability = agileCrmClientDealEntity.Probability,
                Value = agileCrmClientDealEntity.Value,
                CustomData = agileCrmServerCustomDataEntities
            };

            return agileCrmServerDealEntity;
        }
    }
}