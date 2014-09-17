using System.Net;
using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class ScorecardServiceUT : BaseTest
    {
        [TestCase(19)]
        public void When_listing_scorecards_Should_get_scorecards(int expectedCount)
        {
            var scorecards = Api.Scorecards.List().Fetch().Result;
            Assert.That(scorecards.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("1", "Verksamhetsplan")]
        public void When_retrieving_scorecard_by_id_Should_get_scorecard(string id, string expectedName)
        {
            var scorecardDto = Api.Scorecards.Get(id).Fetch().Result;
            Assert.That(scorecardDto, Is.Not.Null);
            Assert.That(scorecardDto.Id, Is.EqualTo(id));
            Assert.That(scorecardDto.Name, Is.EqualTo(expectedName));
        }

        [TestCase("123456")]
        public void When_retrieving_scorecard_by_non_existing_id_Should_fail(string id)
        {
            var request = Api.Scorecards.Get(id);
            Assert.That(request.GetHttpResponse().StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [TestCase("1", "Verksamhetsplan")]
        public void Get_scorecard_columns(string id, string expectedName)
        {
            var columnDtos = Api.Scorecard(id).Columns.Result;
            Assert.That(columnDtos, Is.Not.Null);
            Assert.That(columnDtos.Count, Is.EqualTo(9));
            var columnDto = columnDtos[1];
            Assert.That(columnDto.Name, Is.EqualTo("Områden"));
        }
    }
}