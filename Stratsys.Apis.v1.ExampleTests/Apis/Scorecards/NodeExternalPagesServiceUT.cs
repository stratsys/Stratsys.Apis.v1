using System.Linq;
using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class NodeExternalPagesServiceUT : BaseTest
    {
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Antal heltidstjänster", "My site")]
        public void Get_external_pages_for_node(
            string scorecard, string department, string node, string externalPage)
        {
            var scorecardDto = Api.Scorecards.Filter(scorecard).Result.Single();
            var departmentDto = Api.Departments.Filter(department).Result.Single();
            var nodeDto = Api
                    .Scorecard(scorecardDto.Id)
                    .Department(departmentDto.Id)
                    .Nodes.Filter(node).Result.Single();

            var externalPageDto = Api.ExternalPages
                .List().Fetch().Result.Single(e => e.Name == externalPage);

            var nodeExternalPageDtos = Api
                .Scorecard(scorecardDto.Id)
                .Department(departmentDto.Id)
                .Node(nodeDto.Id)
                .ExternalPages
                .List()
                .Result;

            var nodeExternalPage = nodeExternalPageDtos.FirstOrDefault(k => k.ExternalPage.Id == externalPageDto.Id);
            Assert.That(nodeExternalPage, Is.Not.Null, externalPage);
        }

        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Antal heltidstjänster", "My site")]
        public void Delete_put_external_page_for_node(
            string scorecard, string department, string node, string externalPage)
        {
            var scorecardDto = Api.Scorecards.Filter(scorecard).Result.Single();
            var departmentDto = Api.Departments.Filter(department).Result.Single();
            var nodeDto = Api
                    .Scorecard(scorecardDto.Id)
                    .Department(departmentDto.Id)
                    .Nodes.Filter(node).Result.Single();

            var externalPageDto = Api.ExternalPages
                .List().Fetch().Result.Single(e => e.Name == externalPage);

            var nodeExternalPageResource = Api
                .Scorecard(scorecardDto.Id)
                .Department(departmentDto.Id)
                .Node(nodeDto.Id)
                .ExternalPages;

            var nodeExternalPageDtos = nodeExternalPageResource
                .List()
                .Result;

            var externalPageId = externalPageDto.Id;
            var nodeExternalPage = nodeExternalPageDtos.Single(k => k.ExternalPage.Id == externalPageId);

            var deleteFetch = nodeExternalPageResource
                .Delete(externalPageId).Fetch();

            Assert.That(deleteFetch, Has.Message.Null);

            var putFetch = nodeExternalPageResource
                .Put(externalPageId, nodeExternalPage.UrlSuffix).Fetch();

            Assert.That(putFetch, Has.Message.Null);
        }
    }
}