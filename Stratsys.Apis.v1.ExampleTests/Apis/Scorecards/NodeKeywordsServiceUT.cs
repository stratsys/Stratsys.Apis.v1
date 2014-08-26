using System.Linq;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class NodeKeywordsServiceUT : ClientBaseTest
    {
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Antal heltidstjänster", "Mas")]
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Antal heltidstjänster", "Krav vid upphandlingen")]
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Krav yy", "Krav vid upphandlingen")]
        public void Get_keyword_for_node(
            string scorecard, string department, string node,
            string keyword)
        {
            var scorecardDto = Api.Scorecards.Filter(scorecard).Result.Single();
            var departmentDto = Api.Departments.Filter(department).Result.Single();
            var nodeDto = Api.Scorecard(scorecardDto.Id).Department(departmentDto.Id)
                .Nodes.Filter(node).Result.Single();

            var keywords = Client
                .Path("scorecards", scorecardDto.Id)
                .Path("departments", departmentDto.Id)
                .Path("nodes", nodeDto.Id)
                .Resource<KeywordDto>("keywords")
                .List();

            var dtos = keywords.Where(k => k.Name == keyword).ToList();
            Assert.That(dtos.Count, Is.EqualTo(1), string.Join(",", keywords.Select(k => k.Name)));
        }

        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Antal heltidstjänster", "Mas")]
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Antal heltidstjänster", "Krav vid upphandlingen")]
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Krav yy", "Krav vid upphandlingen")]
        public void Delete_put_keyword_for_node(
            string scorecard, string department, string node,
            string keyword)
        {
            var scorecardDto = Api.Scorecards.Filter(scorecard).Result.Single();
            var departmentDto = Api.Departments.Filter(department).Result.Single();
            var nodeDto = Api.Scorecard(scorecardDto.Id).Department(departmentDto.Id)
                .Nodes.Filter(node).Result.Single();

            var keywords = Client
                .Path("scorecards", scorecardDto.Id)
                .Path("departments", departmentDto.Id)
                .Path("nodes",  nodeDto.Id)
                .Resource<KeywordDto>("keywords");

            var list = keywords.List();
            var dtos = list.Where(k => k.Name == keyword).ToList();
            var dto = dtos.First();

            keywords.Delete(dto.Id);
            
            keywords.Put(dto.Id);
        }
    }
}