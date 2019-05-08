namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SFS.AgileCRM.Library.Data.Responses;
    using SFS.AgileCRM.Library.Data.Static.Internal;

    /// <summary>
    /// The Serialization Extensions.
    /// </summary>
    internal static class SerializationExtensions
    {
        /// <summary>
        /// The HTTP content media type.
        /// </summary>
        private const string MediaType = "application/json";

        /// <summary>
        /// The HTTP content encoding type.
        /// </summary>
        private static readonly Encoding EncodingType = Encoding.UTF8;

        /// <summary>
        /// The serializer settings.
        /// </summary>
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        /// <summary>
        /// Deserializes the argument to a given object.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="json">The json.</param>
        /// <param name="anonymousObject">The anonymous object.</param>
        /// <returns>
        ///   <see cref="!:TObject" />.
        /// </returns>
        public static TObject DeserializeJson<TObject>(this string json, TObject anonymousObject = default)
        {
            var deserializedJson = default(TObject);
            if (anonymousObject == default)
            {
                deserializedJson = JsonConvert.DeserializeAnonymousType(json, anonymousObject, SerializerSettings);
            }
            else
            {
                deserializedJson = JsonConvert.DeserializeObject<TObject>(json, SerializerSettings);
            }

            return deserializedJson;
        }

        /// <summary>
        /// Deserializes AgileCRM server property objects to AgileCRM client property objects.
        /// </summary>
        /// <param name="httpContentAsJObject">The HTTP content as json object.</param>
        /// <returns>
        ///   <see cref="List{T}" />.
        /// </returns>
        public static IList<AgileCrmPropertyEntityBase> ToPropertiesCollection(this JObject httpContentAsJObject)
        {
            // AgileCRM data enters the method as a JObject (.NET JSON Object), then the "properties" object is
            // found within the JObject and its child objects (which are discrete properties) are used as a
            // collection. The collection is then observed for objects where the "type" key is equal to "SYSTEM",
            // each of those objects is then observed individually so that it can be conditionally deserialized
            // to a AgileCRM property object and added to a collection of AgileCRM property objects.

            var agileCrmServerPropertyBases = new List<AgileCrmPropertyEntityBase>();

            foreach (var property in httpContentAsJObject["properties"].Children().Where(property => (string)property["type"] == PropertyType.System))
            {
                var agileCrmServerPropertyBase = default(AgileCrmPropertyEntityBase);

                if ((string)property["name"] == "address")
                {
                    agileCrmServerPropertyBase = JsonConvert.DeserializeObject<
                        AgileCrmPropertyAddressEntity>(property.ToString());
                }

                if (property["subtype"] != null)
                {
                    agileCrmServerPropertyBase = JsonConvert.DeserializeObject<
                        AgileCrmPropertySubTypeEntity>(property.ToString());
                }
                else
                {
                    agileCrmServerPropertyBase = JsonConvert.DeserializeObject<
                        AgileCrmPropertyEntity>(property.ToString());
                }

                agileCrmServerPropertyBases.Add(agileCrmServerPropertyBase);
            }

            return agileCrmServerPropertyBases;
        }

        /// <summary>
        /// Serializes the arugment to string content.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <see cref="StringContent"/>.
        /// </returns>
        public static StringContent ToStringContent(this object entity)
        {
            var serializedEntity = JsonConvert.SerializeObject(entity, SerializerSettings);

            var stringContent = new StringContent(serializedEntity, EncodingType, MediaType);

            return stringContent;
        }
    }
}