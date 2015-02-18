using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class ScorecardViewServiceUT : BaseTest
    {
        [TestCase(5)]
        public void Filter_scorecard_views(int expectedCount)
        {
            var scorecard = Api.Scorecards.Filter("SOSFS 2011:9").Fetch().Result[0];
            var column = Api.ScorecardColumns.Filter(scorecard.Id).Result[2];
            Assert.That(column.Name, Is.EqualTo("Process"));

            var scorecardViews = Api.ScorecardViews.Filter(column.Id).Fetch().Result;
            Assert.That(scorecardViews.Count, Is.EqualTo(expectedCount));
            var view = scorecardViews[0];

            Assert.That(view.Id, Is.EqualTo("124"));
            Assert.That(view.Name, Is.EqualTo("Planera Kvalitetsplan"));
            Assert.That(view.Description, Is.StringStarting("Denna vy är särskillt anpassad för att du ska kunna"));
            Assert.That(view.BaseUrl, Is.EqualTo("https://www.stratsys.se/PermaLink/ApiPublicTests/ScorecardView.mvc?keyId=124&MenuContainerId=502"));
        }

        [Test]
        public void Get_filter_url_for_node()
        {
            var url = Api.ScorecardViews.GetUrl("124", nodeId: "23838").Fetch().Result;
            Assert.That(url, Is.EqualTo("https://www.stratsys.se/PermaLink/ApiPublicTests/ScorecardView.mvc?keyId=124&MenuContainerId=502&NodeIdentifierId=23838"));
        }

        [Test]
        public void Get_filter_url_for_department()
        {
            var url = Api.ScorecardViews.GetUrl("124", "1").Fetch().Result;
            Assert.That(url, Is.EqualTo("https://www.stratsys.se/PermaLink/ApiPublicTests/ScorecardView.mvc?keyId=124&ChangeDepartment=1&MenuContainerId=502"));
        }

        [Test]
        public void Get_filter_url_for_department_and_node()
        {
            var url = Api.ScorecardViews.GetUrl("124", "1", "23838").Fetch().Result;
            Assert.That(url, Is.EqualTo("https://www.stratsys.se/PermaLink/ApiPublicTests/ScorecardView.mvc?keyId=124&ChangeDepartment=1&MenuContainerId=502&NodeIdentifierId=23838"));
        }
    }
}