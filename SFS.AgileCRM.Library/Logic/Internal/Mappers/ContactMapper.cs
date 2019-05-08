namespace SFS.AgileCRM.Library.Logic.Internal.Mappers
{
    using System.Collections.Generic;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Responses;
    using SFS.AgileCRM.Library.Data.Static.Internal;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

    /// <summary>
    /// The Contact Mapper.
    /// </summary>
    internal static class ContactMapper
    {
        /// <summary>
        /// Maps a AgileCrmContactEntity onto a ContactEntityBase.
        /// </summary>
        /// <param name="agileCrmContactModel">The AgileCRM contact model.</param>
        /// <returns>
        ///   <see cref="AgileCrmContactEntity" />.
        /// </returns>
        public static AgileCrmContactEntity ToContactEntityBase(this AgileCrmContactRequest agileCrmContactModel)
        {
            var agileCrmPropertyEntities = new List<AgileCrmPropertyEntityBase>
            {
                new AgileCrmPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = ContactPropertyName.Title,
                    Value = agileCrmContactModel.Title
                },

                new AgileCrmPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = ContactPropertyName.FirstName,
                    Value = agileCrmContactModel.FirstName
                },

                new AgileCrmPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = ContactPropertyName.LastName,
                    Value = agileCrmContactModel.LastName
                },

                new AgileCrmPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = ContactPropertyName.Company,
                    Value = agileCrmContactModel.CompanyName
                }
            };

            foreach (var keyValuePair in agileCrmContactModel.Phone)
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

            foreach (var keyValuePair in agileCrmContactModel.Email)
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

            foreach (var keyValuePair in agileCrmContactModel.Website)
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
                        Address = agileCrmContactModel.Address,
                        City = agileCrmContactModel.City,
                        State = agileCrmContactModel.State,
                        Country = agileCrmContactModel.Country,
                        ZipCode = agileCrmContactModel.ZipCode
                    },
                    SubType = agileCrmContactModel.AddressType.ToAddressTypeValue()
                });

            foreach (var keyValuePair in agileCrmContactModel.CustomFields)
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

            foreach (var stringItem in agileCrmContactModel.Tags)
            {
                tagsCollection.Add(stringItem);
            }

            var agileCrmServerContactEntity = new AgileCrmContactEntity
            {
                // Id = (set by calling method if required).
                // CompanyId = (set by calling method if required).
                StarValue = agileCrmContactModel.StarValue,
                LeadScore = agileCrmContactModel.LeadScore,
                Properties = agileCrmPropertyEntities,
                Tags = tagsCollection
            };

            return agileCrmServerContactEntity;
        }
    }
}