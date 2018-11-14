namespace Osw.Lib.DataAccess.AgileCrm.Entities
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The AgileCRM Server Extended Property Entity.
    /// </summary>
    /// <seealso cref="Osw.Lib.DataAccess.AgileCrm.Entities.AgileCrmServerPropertyEntity" />
    [DataContract]
    public class AgileCrmServerExtendedPropertyEntity : AgileCrmServerPropertyEntity
    {
        /// <summary>
        /// Gets or sets the property sub type.
        /// </summary>
        [DataMember(Name = "subtype", Order = 4)]
        public string SubType { get; set; }
    }
}