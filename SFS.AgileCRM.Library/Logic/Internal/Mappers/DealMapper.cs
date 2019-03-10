namespace SFS.AgileCRM.Library.Logic.Internal.Mappers
{
    using System.Collections.Generic;
    using SFS.AgileCRM.Library.Entities.Deals;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

    /// <summary>
    /// The Deal Mapper.
    /// </summary>
    internal static class DealMapper
    {
        /// <summary>
        /// Maps a AgileCRM domain model onto a AgileCRM entity model.
        /// </summary>
        /// <param name="agileCrmDealModel">The AgileCRM deal model.</param>
        /// <returns>
        ///   <see cref="AgileCrmDealEntity" />.
        /// </returns>
        public static AgileCrmDealEntity ToDealEntity(this AgileCrmDealModel agileCrmDealModel)
        {
            var agileCrmCustomDataEntities = new List<AgileCrmCustomDataEntity>();

            foreach (var item in agileCrmDealModel.CustomFields)
            {
                agileCrmCustomDataEntities.Add(
                    new AgileCrmCustomDataEntity
                    {
                        Name = item.Key,
                        Value = item.Value
                    });
            }

            var agileCrmServerDealEntity = new AgileCrmDealEntity
            {
                // Id = (set in method only).
                // TrackId = (retrieved only).
                // ContactId = (retrieved only).
                Name = agileCrmDealModel.Name,
                CloseDate = agileCrmDealModel.CloseDate.ToEpoch(),
                Milestone = agileCrmDealModel.Milestone,
                Probability = agileCrmDealModel.Probability,
                Value = agileCrmDealModel.Value,
                CustomData = agileCrmCustomDataEntities
            };

            return agileCrmServerDealEntity;
        }
    }
}