namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// The Implementation Fields.
    /// </summary>
    internal static class ImplementationFields
    {
        /// <summary>
        /// The HTTP content media type.
        /// </summary>
        public const string MediaType = "application/json";

        /// <summary>
        /// The HTTP content encoding type.
        /// </summary>
        public static readonly Encoding EncodingType = Encoding.UTF8;

        /// <summary>
        /// The serializer settings.
        /// </summary>
        public static readonly JsonSerializerSettings SerializerSettings =
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
    }
}