namespace SFS.AgileCRM.Library.Logic.Internal.Mappers
{
    using System.Collections.Generic;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;
    using SFS.AgileCRM.Library.Data.Static.Internal;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

    /// <summary>
    /// The Company Mapper.
    /// </summary>
    internal static class CompanyMapper
    {
        /// <summary>
        /// Maps a AgileCrmCompanyEntity onto a CompanyEntityBase.
        /// </summary>
        /// <param name="agileCrmCompanyModel">The AgileCRM company model.</param>
        /// <returns>
        ///   <see cref="AgileCrmCompanyEntity" />.
        /// </returns>
        public static AgileCrmCompanyEntity ToCompanyEntityBase(this AgileCrmCompanyRequest agileCrmCompanyModel)
        {
            var agileCrmPropertyEntities = new List<AgileCrmPropertyEntityBase>
            {
                new AgileCrmPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = CompanyPropertyName.Name,
                    Value = agileCrmCompanyModel.Name
                },

                new AgileCrmPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = CompanyPropertyName.URL,
                    Value = agileCrmCompanyModel.URL
                }
            };

            foreach (var keyValuePair in agileCrmCompanyModel.Phone)
            {
                agileCrmPropertyEntities.Add(
                    new AgileCrmPropertySubTypeEntity
                    {
                        Type = PropertyType.System,
                        Name = PropertyName.Phone,
                        Value = keyValuePair.Value,
                        SubType = keyValuePair.Key.ToPhoneTypeValue()
                    });
            }

            foreach (var keyValuePair in agileCrmCompanyModel.Email)
            {
                agileCrmPropertyEntities.Add(
                new AgileCrmPropertySubTypeEntity
                {
                    Type = PropertyType.System,
                    Name = PropertyName.Email,
                    Value = keyValuePair.Value,
                    SubType = keyValuePair.Key.ToEmailTypeValue()
                });
            }

            foreach (var keyValuePair in agileCrmCompanyModel.Website)
            {
                agileCrmPropertyEntities.Add(
                    new AgileCrmPropertySubTypeEntity
                    {
                        Type = PropertyType.System,
                        Name = PropertyName.Website,
                        Value = keyValuePair.Value,
                        SubType = keyValuePair.Key.ToWebsiteTypeValue()
                    });
            }

            agileCrmPropertyEntities.Add(
                new AgileCrmPropertyAddressEntity
                {
                    Type = PropertyType.System,
                    Name = PropertyName.Address,
                    Value = new AgileCrmAddressEntity
                    {
                        Address = agileCrmCompanyModel.Address,
                        City = agileCrmCompanyModel.City,
                        State = agileCrmCompanyModel.State,
                        Country = agileCrmCompanyModel.Country,
                        ZipCode = agileCrmCompanyModel.ZipCode
                    },
                    SubType = agileCrmCompanyModel.AddressType.ToAddressTypeValue()
                });

            foreach (var keyValuePair in agileCrmCompanyModel.CustomFields)
            {
                agileCrmPropertyEntities.Add(
                    new AgileCrmPropertyEntity
                    {
                        Type = PropertyType.Custom,
                        Name = keyValuePair.Key,
                        Value = keyValuePair.Value
                    });
            }

            var tagsCollection = new List<string>();

            foreach (var stringItem in agileCrmCompanyModel.Tags)
            {
                tagsCollection.Add(stringItem);
            }

            var agileCrmServerCompanyEntity = new AgileCrmCompanyEntity
            {
                // Id = (set by calling method if required).
                LeadScore = agileCrmCompanyModel.LeadScore,
                StarValue = agileCrmCompanyModel.StarValue,
                Properties = agileCrmPropertyEntities,
                Tags = tagsCollection
            };

            return agileCrmServerCompanyEntity;
        }
    }
}