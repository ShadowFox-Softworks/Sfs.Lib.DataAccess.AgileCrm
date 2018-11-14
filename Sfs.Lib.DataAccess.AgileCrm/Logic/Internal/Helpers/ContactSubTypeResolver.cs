namespace Osw.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Contacts;
    using Osw.Lib.DataAccess.AgileCrm.Entities.Contacts.Internal;

    /// <summary>
    /// The Contact Sub Type Resolver.
    /// </summary>
    internal static class ContactSubTypeResolver
    {
        /// <summary>
        /// The contact property subtype resolver repository.
        /// </summary>
        private static readonly IDictionary<AgileCrmClientSubType, string> Repository = new Dictionary<AgileCrmClientSubType, string>
        {
            // ----------------------------------------------
            //  Keys must exist in AgileCrmClientSubType.
            // ----------------------------------------------
            //  Values must exist in ContactPropertySubType.
            // ----------------------------------------------
            { AgileCrmClientSubType.AddressHome, ContactPropertySubType.AddressHome },
            { AgileCrmClientSubType.AddressOffice, ContactPropertySubType.AddressOffice },
            { AgileCrmClientSubType.AddressPostal, ContactPropertySubType.AddressPostal },
            { AgileCrmClientSubType.EmailPersonal, ContactPropertySubType.EmailPersonal },
            { AgileCrmClientSubType.EmailWork, ContactPropertySubType.EmailWork },
            { AgileCrmClientSubType.PhoneHome, ContactPropertySubType.PhoneHome },
            { AgileCrmClientSubType.PhoneHomeFax, ContactPropertySubType.PhoneHomeFax },
            { AgileCrmClientSubType.PhoneMain, ContactPropertySubType.PhoneMain },
            { AgileCrmClientSubType.PhoneMobile, ContactPropertySubType.PhoneMobile },
            { AgileCrmClientSubType.PhoneOther, ContactPropertySubType.PhoneOther },
            { AgileCrmClientSubType.PhoneWork, ContactPropertySubType.PhoneWork },
            { AgileCrmClientSubType.PhoneWorkFax, ContactPropertySubType.PhoneWorkFax },
            { AgileCrmClientSubType.WebsiteBlog, ContactPropertySubType.WebsiteBlog },
            { AgileCrmClientSubType.WebsiteFacebook, ContactPropertySubType.WebsiteFacebook },
            { AgileCrmClientSubType.WebsiteFlickr, ContactPropertySubType.WebsiteFlickr },
            { AgileCrmClientSubType.WebsiteGitHub, ContactPropertySubType.WebsiteGitHub },
            { AgileCrmClientSubType.WebsiteGooglePlus, ContactPropertySubType.WebsiteGooglePlus },
            { AgileCrmClientSubType.WebsiteLinkedIn, ContactPropertySubType.WebsiteLinkedIn },
            { AgileCrmClientSubType.WebsiteSkype, ContactPropertySubType.WebsiteSkype },
            { AgileCrmClientSubType.WebsiteTwitter, ContactPropertySubType.WebsiteTwitter },
            { AgileCrmClientSubType.WebsiteUrl, ContactPropertySubType.WebsiteUrl },
            { AgileCrmClientSubType.WebsiteXing, ContactPropertySubType.WebsiteXing },
            { AgileCrmClientSubType.WebsiteYouTube, ContactPropertySubType.WebsiteYouTube }
        };

        /// <summary>
        /// Gets the value of the sub type.
        /// </summary>
        /// <param name="subType">Type of the sub.</param>
        /// <returns>
        ///   <see cref="string"/>.
        /// </returns>
        public static string GetValue(this AgileCrmClientSubType subType)
        {
            //var type = typeof(ContactPropertySubType);
            //var field = type.GetField(subType.ToString());
            //var value = field.GetValue(null).ToString();

            return typeof(ContactPropertySubType).GetField(subType.ToString()).GetValue(null).ToString();
        }

        /// <summary>
        /// Gets the value of the sub type.
        /// </summary>
        /// <param name="subType">Type of the sub.</param>
        /// <returns>
        ///   <see cref="string"/>.
        /// </returns>
        //public static string GetValue(this AgileCrmClientSubType subType)
        //{
        //    Repository.TryGetValue(subType, out var name);
        //
        //    return name;
        //}
    }
}