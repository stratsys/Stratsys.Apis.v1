using System.Net;
using NUnit.Framework;
using Stratsys.Apis.v1.Apis.Scorecards;
using Stratsys.Apis.v1.Tests;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class ScorecardServiceUT : BaseTest
    {
        [TestCase(18)]
        public void When_listing_scorecards_Should_get_scorecards(int expectedCount)
        {
            var scorecards = Scorecards.List().Fetch().Result;
            Assert.That(scorecards.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("1", "Verksamhetsplan")]
        public void When_retrieving_scorecard_by_id_Should_get_scorecard(string id, string expectedName)
        {
            var department = Scorecards.Get(id).Fetch().Result;
            Assert.That(department, Is.Not.Null);
            Assert.That(department.Id, Is.EqualTo(id));
            Assert.That(department.Name, Is.EqualTo(expectedName));
        }

        [TestCase("123456")]
        public void When_retrieving_scorecard_by_non_existing_id_Should_fail(string id)
        {
            var request = Scorecards.Get(id);
            Assert.That(request.GetHttpResponse().StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            var stratsysApiMetadata = request.Fetch();
            Assert.That(stratsysApiMetadata.Success, Is.False);
            Assert.That(stratsysApiMetadata.Message, Is.EqualTo("Scorecard undefined: 123456"));
            Assert.That(stratsysApiMetadata.Result, Is.Null);
        }

        private ScorecardResource Scorecards
        {
            get
            {
                return new ScorecardService(ClientId, ClientSecret).Scorecards;
            }
        }
    }
}