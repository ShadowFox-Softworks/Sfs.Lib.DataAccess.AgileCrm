namespace Sfs.Lib.DataAccess.AgileCrm.Entities
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Server Address Entity.
    /// </summary>
    [DataContract]
    public class AgileCrmServerAddressEntity
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [DataMember(Name = "address", Order = 1)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the address's city.
        /// </summary>
        [DataMember(Name = "city", Order = 2)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address's country.
        /// </summary>
        [DataMember(Name = "country", Order = 5)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the address's state.
        /// </summary>
        [DataMember(Name = "state", Order = 3)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the address's postal/zip code.
        /// </summary>
        [DataMember(Name = "zip", Order = 4)]
        public string ZipCode { get; set; }
    }
}