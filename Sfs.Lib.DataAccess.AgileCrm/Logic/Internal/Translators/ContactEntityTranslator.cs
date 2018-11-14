namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Translators
{
    using System.Collections.Generic;
    using Osw.Lib.DataAccess.AgileCrm.Entities;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Contacts;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Contacts.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal;
    using Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers;

    /// <summary>
    /// The Contact Entity Translator.
    /// </summary>
    internal static class ContactEntityTranslator
    {
        /// <summary>
        /// Translates the AgileCRM client entity to a AgileCRM server entity.
        /// </summary>
        /// <param name="agileCrmClientContactEntity">The agile CRM client contact entity.</param>
        /// <returns>
        ///   <see cref="AgileCrmServerContactEntity" />.
        /// </returns>
        public static AgileCrmServerContactEntity ToServerEntity(this AgileCrmClientContactEntity agileCrmClientContactEntity)
        {
            // TODO: Address stuff

            var agileCrmServerPropertyEntities = new List<AgileCrmServerPropertyEntity>();

            if (agileCrmClientContactEntity.Title != null)
            {
                agileCrmServerPropertyEntities.Add(
                    new AgileCrmServerPropertyEntity
                    {
                        Type = ContactPropertyType.System,
                        Name = ContactPropertyName.Title,
                        Value = agileCrmClientContactEntity.Title
                    });
            }

            if (agileCrmClientContactEntity.FirstName != null)
            {
                agileCrmServerPropertyEntities.Add(
                    new AgileCrmServerPropertyEntity
                    {
                        Type = ContactPropertyType.System,
                        Name = ContactPropertyName.FirstName,
                        Value = agileCrmClientContactEntity.FirstName
                    });
            }

            if (agileCrmClientContactEntity.LastName != null)
            {
                agileCrmServerPropertyEntities.Add(
                    new AgileCrmServerPropertyEntity
                    {
                        Type = ContactPropertyType.System,
                        Name = ContactPropertyName.LastName,
                        Value = agileCrmClientContactEntity.LastName
                    });
            }

            if (agileCrmClientContactEntity.CompanyName != null)
            {
                agileCrmServerPropertyEntities.Add(
                    new AgileCrmServerPropertyEntity
                    {
                        Type = ContactPropertyType.System,
                        Name = ContactPropertyName.Company,
                        Value = agileCrmClientContactEntity.CompanyName
                    });
            }

            if (agileCrmClientContactEntity.PhoneNumber != null)
            {
                foreach (var item in agileCrmClientContactEntity.PhoneNumber)
                {
                    agileCrmServerPropertyEntities.Add(
                        new AgileCrmServerExtendedPropertyEntity
                        {
                            Type = ContactPropertyType.System,
                            Name = GeneralPropertyName.Phone,
                            Value = item.Value,
                            SubType = item.SubType.GetValue()
                        });
                }
            }

            if (agileCrmClientContactEntity.EmailAddress != null)
            {
                foreach (var item in agileCrmClientContactEntity.EmailAddress)
                {
                    agileCrmServerPropertyEntities.Add(
                    new AgileCrmServerExtendedPropertyEntity
                    {
                        Type = ContactPropertyType.System,
                        Name = GeneralPropertyName.Email,
                        Value = item.Value,
                        SubType = item.SubType.ToString()
                    });
                }
            }

            if (agileCrmClientContactEntity.Website != null)
            {
                foreach (var item in agileCrmClientContactEntity.Website)
                {
                    agileCrmServerPropertyEntities.Add(
                        new AgileCrmServerExtendedPropertyEntity
                        {
                            Type = ContactPropertyType.System,
                            Name = GeneralPropertyName.Website,
                            Value = item.Value,
                            SubType = item.SubType.GetValue()
                        });
                }
            }

            if (agileCrmClientContactEntity.CustomFields != null)
            {
                foreach (var item in agileCrmClientContactEntity.CustomFields)
                {
                    agileCrmServerPropertyEntities.Add(
                        new AgileCrmServerPropertyEntity
                        {
                            Type = ContactPropertyType.Custom,
                            Name = item.Key,
                            Value = item.Value
                        });
                }
            }

            var tagsCollection = new List<string>();

            if (agileCrmClientContactEntity.Tags != null)
            {
                foreach (var item in agileCrmClientContactEntity.Tags)
                {
                    tagsCollection.Add(item);
                }
            }

            return new AgileCrmServerContactEntity
            {
                // AgileCrmServerContactEntity.Id (set in update method only).
                // AgileCrmServerContactEntity.CompanyId (set in update method only).
                StarValue = agileCrmClientContactEntity.StarValue,
                LeadScore = agileCrmClientContactEntity.LeadScore,
                Properties = agileCrmServerPropertyEntities,
                Tags = tagsCollection
            };
        }
    }
}