namespace SFS.AgileCRM.Library.Logic.Internal.Mappers
{
    using System.Collections.Generic;
    using SFS.AgileCRM.Library.Entities;
    using SFS.AgileCRM.Library.Entities.Contacts;
    using SFS.AgileCRM.Library.Entities.Contacts.Internal;
    using SFS.AgileCRM.Library.Entities.Internal;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

    /// <summary>
    /// The Contact Mapper.
    /// </summary>
    internal static class ContactMapper
    {
        /// <summary>
        /// Maps a AgileCRM domain model onto a AgileCRM entity model.
        /// </summary>
        /// <param name="agileCrmContactModel">The AgileCRM contact model.</param>
        /// <returns>
        ///   <see cref="AgileCrmContactEntity" />.
        /// </returns>
        public static AgileCrmContactEntity ToContactEntity(this AgileCrmContactModel agileCrmContactModel)
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

            foreach (var item in agileCrmContactModel.PhoneNumber)
            {
                agileCrmPropertyEntities.Add(
                    new AgileCrmPropertySubTypeEntity
                    {
                        Type = PropertyType.System,
                        Name = PropertyName.Phone,
                        Value = item.Value,
                        SubType = item.SubType.ToPropertyValue()
                    });
            }

            foreach (var item in agileCrmContactModel.EmailAddress)
            {
                agileCrmPropertyEntities.Add(
                new AgileCrmPropertySubTypeEntity
                {
                    Type = PropertyType.System,
                    Name = PropertyName.Email,
                    Value = item.Value,
                    SubType = item.SubType.ToString()
                });
            }

            foreach (var item in agileCrmContactModel.Website)
            {
                agileCrmPropertyEntities.Add(
                    new AgileCrmPropertySubTypeEntity
                    {
                        Type = PropertyType.System,
                        Name = PropertyName.Website,
                        Value = item.Value,
                        SubType = item.SubType.ToPropertyValue()
                    });
            }

            agileCrmPropertyEntities.Add(
                new AgileCrmPropertyAddressEntity
                {
                    Type = PropertyType.System,
                    Name = PropertyName.Address,
                    Value = new AgileCrmAddressEntity
                    {
                        Address = agileCrmContactModel.AddressInformation.Address,
                        City = agileCrmContactModel.AddressInformation.City,
                        State = agileCrmContactModel.AddressInformation.State,
                        Country = agileCrmContactModel.AddressInformation.Country,
                        ZipCode = agileCrmContactModel.AddressInformation.ZipCode
                    },
                    SubType = agileCrmContactModel.AddressInformation.SubType.ToPropertyValue()
                });

            foreach (var item in agileCrmContactModel.CustomFields)
            {
                agileCrmPropertyEntities.Add(
                    new AgileCrmPropertyEntity
                    {
                        Type = PropertyType.Custom,
                        Name = item.Key,
                        Value = item.Value
                    });
            }

            var tagsCollection = new List<string>();

            foreach (var item in agileCrmContactModel.Tags)
            {
                tagsCollection.Add(item);
            }

            var agileCrmServerContactEntity = new AgileCrmContactEntity
            {
                // Id = (set in method only).
                // CompanyId = (set in method only).
                StarValue = agileCrmContactModel.StarValue,
                LeadScore = agileCrmContactModel.LeadScore,
                Properties = agileCrmPropertyEntities,
                Tags = tagsCollection
            };

            return agileCrmServerContactEntity;
        }
    }
}