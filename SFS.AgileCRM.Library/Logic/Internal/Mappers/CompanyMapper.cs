namespace SFS.AgileCRM.Library.Logic.Internal.Mappers
{
    using System.Collections.Generic;
    using SFS.AgileCRM.Library.Entities;
    using SFS.AgileCRM.Library.Entities.Companies;
    using SFS.AgileCRM.Library.Entities.Companies.Internal;
    using SFS.AgileCRM.Library.Entities.Internal;
    using SFS.AgileCRM.Library.Logic.Internal.Helpers;

    /// <summary>
    /// The Company Mapper.
    /// </summary>
    internal static class CompanyMapper
    {
        /// <summary>
        /// Maps a AgileCRM domain model onto a AgileCRM entity model.
        /// </summary>
        /// <param name="agileCrmCompanyModel">The AgileCRM company model.</param>
        /// <returns>
        ///   <see cref="AgileCrmCompanyEntity" />.
        /// </returns>
        public static AgileCrmCompanyEntity ToCompanyEntity(this AgileCrmCompanyModel agileCrmCompanyModel)
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

            foreach (var item in agileCrmCompanyModel.PhoneNumber)
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

            foreach (var item in agileCrmCompanyModel.EmailAddress)
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

            foreach (var item in agileCrmCompanyModel.Website)
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
                        Address = agileCrmCompanyModel.AddressInformation.Address,
                        City = agileCrmCompanyModel.AddressInformation.City,
                        State = agileCrmCompanyModel.AddressInformation.State,
                        Country = agileCrmCompanyModel.AddressInformation.Country,
                        ZipCode = agileCrmCompanyModel.AddressInformation.ZipCode
                    },
                    SubType = agileCrmCompanyModel.AddressInformation.SubType.ToPropertyValue()
                });

            foreach (var item in agileCrmCompanyModel.CustomFields)
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

            foreach (var item in agileCrmCompanyModel.Tags)
            {
                tagsCollection.Add(item);
            }

            var agileCrmServerCompanyEntity = new AgileCrmCompanyEntity
            {
                // Id = (set in method only).
                LeadScore = agileCrmCompanyModel.LeadScore,
                StarValue = agileCrmCompanyModel.StarValue,
                Properties = agileCrmPropertyEntities,
                Tags = tagsCollection
            };

            return agileCrmServerCompanyEntity;
        }
    }
}