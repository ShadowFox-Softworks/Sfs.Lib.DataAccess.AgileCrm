namespace SFS.AgileCRM.Test.Unit.Serialization
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using SFS.AgileCRM.Library.Data.Requests;
    using SFS.AgileCRM.Library.Data.Static;
    using SFS.AgileCRM.Library.Logic.Internal.Mappers;

    /// <summary>
    /// The Entity Validation Unit Tests.
    /// </summary>
    [TestFixture]
    public class RequestSerializationTests : TestBase
    {
        /// <summary>
        ///
        /// </summary>
        [Test]
        public void MethodName()
        {
            // Arrange
            var agileCrmContactRequest = new AgileCrmContactRequest
            {
                LeadScore = 100,
                StarValue = 5,
                Title = "Title",
                FirstName = "FirstName",
                LastName = "LastName",
                EmailAddress = new List<AgileCrmSubTypeRequest>
                {
                    new AgileCrmSubTypeRequest
                    {
                        SubType = AgileCrmPropertySubType.EmailPersonal,
                        Value = "shadowfoxsoftworks@github.com"
                    }
                },
                PhoneNumber = new List<AgileCrmSubTypeRequest>
                {
                    new AgileCrmSubTypeRequest
                    {
                        SubType = AgileCrmPropertySubType.PhoneHome,
                        Value = "00000000000"
                    }
                },
                AddressInformation = new DemographicBase
                {
                    Address = "Address",
                    City = "City",
                    State = "State",
                    Country = "Country",
                    ZipCode = "ZipCode",
                    SubType = AgileCrmPropertySubType.AddressHome
                },
                CompanyName = "CompanyName",
                Website = new List<AgileCrmSubTypeRequest>
                {
                    new AgileCrmSubTypeRequest
                    {
                        SubType = AgileCrmPropertySubType.WebsiteGitHub,
                        Value = "https://www.github.com/ShadowFoxSoftworks/"
                    }
                },
                CustomFields = new Dictionary<string, string>
                {
                    { "Key", "Value" }
                },
                Tags = new List<string>
                {
                    "Tag"
                }
            };

            var agileCrmContactResponse = agileCrmContactRequest.ToContactEntity();

            // Act
            StartStopwatch();

            var result = JsonConvert.SerializeObject(agileCrmContactResponse);

            StopStopwatch();

            // Assert
            Console.WriteLine(result);

            WriteTimeElapsed();
        }
    }
}