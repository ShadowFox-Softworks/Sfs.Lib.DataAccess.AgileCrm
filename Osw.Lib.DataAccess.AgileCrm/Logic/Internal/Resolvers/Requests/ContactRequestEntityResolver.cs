namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Resolvers.Requests
{
    using System.Collections.Generic;
    using Osw.Lib.DataAccess.AgileCrm.Entities;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Bases;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Constants;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Requests;

    /// <summary>
    /// The Contact Request Entity Resolver
    /// </summary>
    internal static class ContactRequestEntityResolver
    {
        /// <summary>
        /// Resolves the argument entity to a AgileCRM request entity.
        /// </summary>
        /// <param name="contactEntity">The contact entity.</param>
        /// <returns>
        ///   <see cref="ContactRequestEntity" />
        /// </returns>
        public static ContactRequestEntity ResolveToCrmRequest(this AgileCrmContactEntity contactEntity)
        {
            var contactPropertiesEntities = new List<ContactPropertiesEntity>();

            if (contactEntity.FirstName != null)
            {
                contactPropertiesEntities.Add(
                    new ContactPropertiesEntity
                    {
                        Type = ContactPropertyType.System,
                        Name = ContactPropertyName.FirstName,
                        Value = contactEntity.FirstName
                    });
            }

            if (contactEntity.LastName != null)
            {
                contactPropertiesEntities.Add(
                    new ContactPropertiesEntity
                    {
                        Type = ContactPropertyType.System,
                        Name = ContactPropertyName.LastName,
                        Value = contactEntity.LastName
                    });
            }

            if (contactEntity.CompanyName != null)
            {
                contactPropertiesEntities.Add(
                    new ContactPropertiesEntity
                    {
                        Type = ContactPropertyType.System,
                        Name = ContactPropertyName.Company,
                        Value = contactEntity.CompanyName
                    });
            }

            if (contactEntity.PhoneNumber != null)
            {
                foreach (var item in contactEntity.PhoneNumber)
                {
                    contactPropertiesEntities.Add(
                        new ContactPropertiesEntity
                        {
                            Type = ContactPropertyType.System,
                            Name = ContactPropertyName.Phone,
                            Value = item
                        });
                }
            }

            if (contactEntity.EmailAddress != null)
            {
                foreach (var item in contactEntity.EmailAddress)
                {
                    contactPropertiesEntities.Add(
                        new ContactPropertiesEntity
                        {
                            Type = ContactPropertyType.System,
                            Name = ContactPropertyName.Email,
                            Value = item
                        });
                }
            }

            var contactTagsEntities = new List<string>();

            if (contactEntity.Tags != null)
            {
                foreach (var item in contactEntity.Tags)
                {
                    contactTagsEntities.Add(item);
                }
            }

            return new ContactRequestEntity
            {
                // ContactRequestEntity.Id should not be set here, only for contact updates
                // ContactRequestEntity.StarValue should not be set here, only for contact creations
                // ContactRequestEntity.LeadScore should not be set here, only for contact creations
                Properties = contactPropertiesEntities.Count != 0 ? contactPropertiesEntities : new List<ContactPropertiesEntity>(),
                Tags = contactTagsEntities.Count != 0 ? contactTagsEntities : new List<string>()
            };
        }
    }
}