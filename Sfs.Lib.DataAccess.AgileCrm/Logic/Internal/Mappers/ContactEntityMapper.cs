namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Mappers
{
    using System.Collections.Generic;
    using Sfs.Lib.DataAccess.AgileCrm.Entities;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Contacts;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Contacts.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <summary>
    /// The Contact Entity Mapper.
    /// </summary>
    internal static class ContactEntityMapper
    {
        /// <summary>
        /// Maps the AgileCRM client entity onto a AgileCRM server entity.
        /// </summary>
        /// <param name="agileCrmClientContactEntity">The agile CRM client contact entity.</param>
        /// <returns>
        ///   <see cref="AgileCrmServerContactEntity" />.
        /// </returns>
        public static AgileCrmServerContactEntity ToServerContactEntity(this AgileCrmClientContactEntity agileCrmClientContactEntity)
        {
            var agileCrmServerPropertyEntities = new List<AgileCrmServerPropertyBase>();

            agileCrmServerPropertyEntities.Add(
                new AgileCrmServerPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = ContactPropertyName.Title,
                    Value = agileCrmClientContactEntity.Title
                });

            agileCrmServerPropertyEntities.Add(
                new AgileCrmServerPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = ContactPropertyName.FirstName,
                    Value = agileCrmClientContactEntity.FirstName
                });

            agileCrmServerPropertyEntities.Add(
                new AgileCrmServerPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = ContactPropertyName.LastName,
                    Value = agileCrmClientContactEntity.LastName
                });

            agileCrmServerPropertyEntities.Add(
                new AgileCrmServerPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = ContactPropertyName.Company,
                    Value = agileCrmClientContactEntity.CompanyName
                });

            foreach (var item in agileCrmClientContactEntity.PhoneNumber)
            {
                agileCrmServerPropertyEntities.Add(
                    new AgileCrmServerPropertySubTypeEntity
                    {
                        Type = PropertyType.System,
                        Name = PropertyName.Phone,
                        Value = item.Value,
                        SubType = item.SubType.ToPropertyValue()
                    });
            }

            foreach (var item in agileCrmClientContactEntity.EmailAddress)
            {
                agileCrmServerPropertyEntities.Add(
                new AgileCrmServerPropertySubTypeEntity
                {
                    Type = PropertyType.System,
                    Name = PropertyName.Email,
                    Value = item.Value,
                    SubType = item.SubType.ToString()
                });
            }

            foreach (var item in agileCrmClientContactEntity.Website)
            {
                agileCrmServerPropertyEntities.Add(
                    new AgileCrmServerPropertySubTypeEntity
                    {
                        Type = PropertyType.System,
                        Name = PropertyName.Website,
                        Value = item.Value,
                        SubType = item.SubType.ToPropertyValue()
                    });
            }

            agileCrmServerPropertyEntities.Add(
                new AgileCrmServerPropertyAddressEntity
                {
                    Type = PropertyType.System,
                    Name = PropertyName.Address,
                    Value = new AgileCrmServerAddressEntity
                    {
                        Address = agileCrmClientContactEntity.AddressInformation.Address,
                        City = agileCrmClientContactEntity.AddressInformation.City,
                        State = agileCrmClientContactEntity.AddressInformation.State,
                        Country = agileCrmClientContactEntity.AddressInformation.Country,
                        ZipCode = agileCrmClientContactEntity.AddressInformation.ZipCode
                    },
                    SubType = agileCrmClientContactEntity.AddressInformation.SubType.ToPropertyValue()
                });

            foreach (var item in agileCrmClientContactEntity.CustomFields)
            {
                agileCrmServerPropertyEntities.Add(
                    new AgileCrmServerPropertyEntity
                    {
                        Type = PropertyType.Custom,
                        Name = item.Key,
                        Value = item.Value
                    });
            }

            var tagsCollection = new List<string>();

            foreach (var item in agileCrmClientContactEntity.Tags)
            {
                tagsCollection.Add(item);
            }

            var agileCrmServerContactEntity = new AgileCrmServerContactEntity
            {
                // AgileCrmServerContactEntity.Id (set in method only).
                // AgileCrmServerContactEntity.CompanyId (set in method only).
                StarValue = agileCrmClientContactEntity.StarValue,
                LeadScore = agileCrmClientContactEntity.LeadScore,
                Properties = agileCrmServerPropertyEntities,
                Tags = tagsCollection
            };

            return agileCrmServerContactEntity;
        }
    }
}