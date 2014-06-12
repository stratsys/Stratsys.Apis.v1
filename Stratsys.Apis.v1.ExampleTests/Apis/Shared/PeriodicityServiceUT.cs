using System.Net;
using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Shared
{
    public class PeriodicityServiceUT : BaseTest
    {
        [TestCase(19)]
        public void When_listing_periodicities_Should_get_periodicities(int expectedNumberOfPeriodicities)
        {
            var periodicities = Api.Periodicities.List().Fetch().Result;
            Assert.That(periodicities.Count, Is.EqualTo(expectedNumberOfPeriodicities));
        }


        [TestCase("1", "År", true)]
        public void When_retrieving_periodicity_by_id_Should_get_periodicity(string id, 
            string expectedName, bool expectedIsActive)
        {
            var periodicity = Api.Periodicities.Get(id).Fetch().Result;
            Assert.That(periodicity, Is.Not.Null);
            Assert.That(periodicity.Id, Is.EqualTo(id));
            Assert.That(periodicity.Name, Is.EqualTo(expectedName));
            Assert.That(periodicity.IsActive, Is.EqualTo(expectedIsActive));
        }

        [TestCase("123456")]
        public void When_retrieving_periodicity_by_non_existing_id_Should_fail(string id)
        {
            var request = Api.Periodicities.Get(id);
            Assert.That(request.GetHttpResponse().StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            var stratsysApiMetadata = request.Fetch();
            Assert.That(stratsysApiMetadata.Success, Is.False);
            Assert.That(stratsysApiMetadata.Message, Is.EqualTo("Periodicity undefined: 123456"));
            Assert.That(stratsysApiMetadata.Result, Is.Null);
        }
    }
}