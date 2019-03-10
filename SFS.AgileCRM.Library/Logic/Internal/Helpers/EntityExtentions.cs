namespace SFS.AgileCRM.Library.Logic.Internal.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using SFS.AgileCRM.Library.Entities;

    /// <summary>
    /// The Entity Extentions.
    /// </summary>
    internal static class EntityExtentions
    {
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

            foreach (var property in httpContentAsJObject["properties"].Children().Where(property => (string)property["type"] == "SYSTEM"))
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
    }
}