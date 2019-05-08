namespace SFS.AgileCRM.Library.Logic.Internal.Mappers
{
    using System.Collections.Generic;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

    /// <summary>
    /// The Deal Mapper.
    /// </summary>
    internal static class DealMapper
    {
        /// <summary>
        /// Maps a AgileCrmDealEntity onto a DealEntityBase.
        /// </summary>
        /// <param name="agileCrmDealModel">The AgileCRM deal model.</param>
        /// <returns>
        ///   <see cref="AgileCrmDealEntity" />.
        /// </returns>
        public static AgileCrmDealEntity ToDealEntityBase(this AgileCrmDealRequest agileCrmDealModel)
        {
            var agileCrmCustomDataEntities = new List<AgileCrmCustomDataEntity>();

            foreach (var keyValuePair in agileCrmDealModel.CustomFields)
            {
                agileCrmCustomDataEntities.Add(
                    new AgileCrmCustomDataEntity
                    {
                        Name = keyValuePair.Key,
                        Value = keyValuePair.Value
                    });
            }

            var agileCrmServerDealEntity = new AgileCrmDealEntity
            {
                // Id = (set by calling method if required).
                // TrackId = (set by calling method if required).
                // ContactId = (set by calling method if required).
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