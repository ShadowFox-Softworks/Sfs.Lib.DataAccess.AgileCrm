namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Mappers
{
    using System.Collections.Generic;
    using Sfs.Lib.DataAccess.AgileCrm.Entities;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Companies;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Companies.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <summary>
    /// The Company Entity Mapper.
    /// </summary>
    internal static class CompanyEntityMapper
    {
        /// <summary>
        /// Maps the AgileCRM client entity onto a AgileCRM server entity.
        /// </summary>
        /// <param name="agileCrmClientCompanyEntity">The agile CRM client company entity.</param>
        /// <returns>
        ///   <see cref="AgileCrmServerCompanyEntity" />.
        /// </returns>
        public static AgileCrmServerCompanyEntity ToServerCompanyEntity(this AgileCrmClientCompanyEntity agileCrmClientCompanyEntity)
        {
            var agileCrmServerPropertyEntities = new List<AgileCrmServerPropertyBase>
            {
                new AgileCrmServerPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = CompanyPropertyName.Name,
                    Value = agileCrmClientCompanyEntity.Name
                },

                new AgileCrmServerPropertyEntity
                {
                    Type = PropertyType.System,
                    Name = CompanyPropertyName.URL,
                    Value = agileCrmClientCompanyEntity.URL
                }
            };

            foreach (var item in agileCrmClientCompanyEntity.PhoneNumber)
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

            foreach (var item in agileCrmClientCompanyEntity.EmailAddress)
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

            foreach (var item in agileCrmClientCompanyEntity.Website)
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
                        Address = agileCrmClientCompanyEntity.AddressInformation.Address,
                        City = agileCrmClientCompanyEntity.AddressInformation.City,
                        State = agileCrmClientCompanyEntity.AddressInformation.State,
                        Country = agileCrmClientCompanyEntity.AddressInformation.Country,
                        ZipCode = agileCrmClientCompanyEntity.AddressInformation.ZipCode
                    },
                    SubType = agileCrmClientCompanyEntity.AddressInformation.SubType.ToPropertyValue()
                });

            foreach (var item in agileCrmClientCompanyEntity.CustomFields)
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

            foreach (var item in agileCrmClientCompanyEntity.Tags)
            {
                tagsCollection.Add(item);
            }

            var agileCrmServerCompanyEntity = new AgileCrmServerCompanyEntity
            {
                // AgileCrmServerCompanyEntity.Id (set in method only).
                LeadScore = agileCrmClientCompanyEntity.LeadScore,
                StarValue = agileCrmClientCompanyEntity.StarValue,
                Properties = agileCrmServerPropertyEntities,
                Tags = tagsCollection
            };

            return agileCrmServerCompanyEntity;
        }
    }
}