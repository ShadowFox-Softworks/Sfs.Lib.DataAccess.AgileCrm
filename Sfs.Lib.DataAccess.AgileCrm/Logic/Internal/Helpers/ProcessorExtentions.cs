namespace Sfs.Lib.DataAccess.AgileCrm.Logic.Internal.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Sfs.Lib.DataAccess.AgileCrm.Entities;

    /// <summary>
    /// The Processor Helpers.
    /// </summary>
    internal static class ProcessorExtentions
    {
        /// <summary>
        /// Deserializes AgileCRM server property objects to AgileCRM client property objects.
        /// </summary>
        /// <param name="httpContentAsJObject">The HTTP content as json object.</param>
        /// <returns>
        ///   <see cref="List{T}" />.
        /// </returns>
        public static IList<AgileCrmServerPropertyBase> ToPropertiesCollection(this JObject httpContentAsJObject)
        {
            // AgileCRM data enters the method as a JObject (.NET JSON Object), then the "properties" object is
            // found within the JObject and its child objects (which are discrete properties) are used as a
            // collection. The collection is then observed for objects where the "type" key is equal to "SYSTEM",
            // each of those objects is then observed individually so that it can be conditionally deserialized
            // to a AgileCRM property object and added to a collection of AgileCRM property objects.

            var agileCrmServerPropertyBases = new List<AgileCrmServerPropertyBase>();

            foreach (var property in
                httpContentAsJObject["properties"].Children().Where(property => (string)property["type"] == "SYSTEM"))
            {
                var agileCrmServerPropertyBase = default(AgileCrmServerPropertyBase);

                if ((string)property["name"] == "address")
                {
                    agileCrmServerPropertyBase = JsonConvert.DeserializeObject<
                        AgileCrmServerPropertyAddressEntity>(property.ToString());
                }

                if (property["subtype"] != null)
                {
                    agileCrmServerPropertyBase = JsonConvert.DeserializeObject<
                        AgileCrmServerPropertySubTypeEntity>(property.ToString());
                }
                else
                {
                    agileCrmServerPropertyBase = JsonConvert.DeserializeObject<
                        AgileCrmServerPropertyEntity>(property.ToString());
                }

                agileCrmServerPropertyBases.Add(agileCrmServerPropertyBase);
            }

            return agileCrmServerPropertyBases;
        }
    }
}