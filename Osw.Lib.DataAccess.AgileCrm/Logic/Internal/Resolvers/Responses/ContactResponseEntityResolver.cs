namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Resolvers.Responses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Osw.Lib.DataAccess.AgileCrm.Entities;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Bases;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Constants;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Internal.Responses;

    /// <summary>
    /// The Contact Response Entity Resolver
    /// </summary>
    internal static class ContactResponseEntityResolver
    {
        /// <summary>
        /// Resolves the argument entity from a AgileCRM response entity.
        /// </summary>
        /// <param name="contactResponseEntity">The contact response entity.</param>
        /// <returns>
        ///   <see cref="AgileCrmContactEntity" />
        /// </returns>
        public static AgileCrmContactEntity ResolveFromCrmResponse(this ContactResponseEntity contactResponseEntity)
        {
            var agileCrmContactEntity = new AgileCrmContactEntity
            {
                FirstName = contactResponseEntity.Properties.Get(ContactPropertyName.FirstName),
                LastName = contactResponseEntity.Properties.Get(ContactPropertyName.LastName),
                CompanyName = contactResponseEntity.Properties.Get(ContactPropertyName.Company),
                LeadScore = Convert.ToInt32(contactResponseEntity.LeadScore),
                StarValue = Convert.ToInt32(contactResponseEntity.StarValue),
                Tags = contactResponseEntity.Tags
            };

            foreach (var item in contactResponseEntity.Properties.Where(r => r.Name == ContactPropertyName.Phone))
            {
                agileCrmContactEntity.PhoneNumber.Add(item.Value);
            }

            foreach (var item in contactResponseEntity.Properties.Where(r => r.Name == ContactPropertyName.Email))
            {
                agileCrmContactEntity.EmailAddress.Add(item.Value);
            }

            return agileCrmContactEntity;
        }

        /// <summary>
        /// Gets the value property of an entity with the specified name property.
        /// </summary>
        /// <param name="contactPropertiesEntities">The contact properties entities.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <see cref="string"/>
        /// </returns>
        private static string Get(
            this IEnumerable<ContactPropertiesEntity> contactPropertiesEntities,
            string name)
        {
            return contactPropertiesEntities?.FirstOrDefault(r => r.Name == name)?.Value;
        }
    }
}