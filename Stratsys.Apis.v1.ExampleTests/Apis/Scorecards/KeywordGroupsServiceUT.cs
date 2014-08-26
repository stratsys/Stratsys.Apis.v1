using System.Linq;
using NUnit.Framework;
using Stratsys.Apis.v1.Clients.Abstractions;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class KeywordGroupsServiceUT : ClientBaseTest
    {

        [TestCase("Verksamhetsplan", "Enhetens mål", "Tillhör plan:")]
        [TestCase("SOSFS 2011:9", "Egenkontroll", "Kontrollmoment för Egenkontroll")]
        [TestCase("SOSFS 2011:9", "Egenkontroll", "Frekvens")]
        [TestCase("SOSFS 2011:9", "Åtgärd", "Typ av åtgärd")]
        public void Get_keyword_for_node(
            string scorecard, string column,
            string keywordGroup)
        {
            var scorecardDto = Api.Scorecards.Filter(scorecard).Result.Single();
            var columnDto = Api.ScorecardColumns.Filter(scorecardDto.Id, column).Fetch().Result.Single();
            var keywordGroupDtos = Api.KeywordGroups.Filter(columnDto.Id).Result;

            var dtos = keywordGroupDtos.Where(k => k.Name == keywordGroup).ToList();
            Assert.That(dtos.Count, Is.EqualTo(1), string.Join(",", keywordGroupDtos.Select(k => k.Name)));
        }

        [TestCase("Verksamhetsplan", "Kommunfullmäktige", "Bostadsbyggnadstakten ska vara hög", "Tillhör plan:")]
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Antal heltidstjänster", "Utförs av:")]
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Antal heltidstjänster", "Typ av krav:")]
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Krav yy", "Utförs av:")]
        [TestCase("Kontraktsuppföljning", "Kommunfullmäktige", "Krav yy", "Typ av krav:")]
        public void Get_keywordgroups_for_node(
            string scorecard, string department, string node,
            string keywordGroup)
        {
            var scorecardDto = Api.Scorecards.Filter(scorecard).Result.Single();
            var departmentDto = Api.Departments.Filter(department).Result.Single();
            var nodeDto = Api
                .Scorecard(scorecardDto.Id)
                .Department(departmentDto.Id)
                .Nodes
                .Filter(node)
                .Result.Single();

            var keywordGroupDtos = Api.KeywordGroups.Filter(nodeDto.Column.Id).Result;

            var dtos = keywordGroupDtos.Where(k => k.Name == keywordGroup).ToList();
            Assert.That(dtos.Count, Is.EqualTo(1), string.Join(",", keywordGroupDtos.Select(k => k.Name)));
 
        }

    }
}