using System;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Organization;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class ScorecardNodeServiceUT : ClientBaseTest
    {
        [TestCase("1", "1", "16365")]
        [TestCase("1", "5", "16365")]
        public void Get_all_for_node(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Resource<ScorecardNodeDto>("nodes");

            var dto = resource.Get(nodeId);
            Assert.That(dto.Name, Is.EqualTo("Arbetskraftens storlek 16-64 år"));
            Assert.That(dto.Scorecard.Name, Is.EqualTo("Verksamhetsplan"));
            Assert.That(dto.ScorecardColumn.Name, Is.EqualTo("Mätetal"));
            Assert.That(dto.Department.Id, Is.EqualTo(departmentId));
        }

        [TestCase("1", "1", 47)]
        public void Get_all_for_scorecard(string scorecardId, string departmentId, int count)
        {
            var dtos = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Resource<ScorecardNodeDto>("nodes").List();
            Assert.That(dtos.Count, Is.EqualTo(count));
        }

        //Bostadsbyggnadstakten ska vara hög
        [TestCase("1", "1", "21412")]
        public void Get_node_for_scorecard(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Resource<ScorecardNodeDto>("nodes");

            var dto = resource.Get(nodeId);
            Assert.That(dto.Name, Is.EqualTo("Bostadsbyggnadstakten ska vara hög"));
            Assert.That(dto.DescriptionFields, Is.Null);
        }

        [TestCase("1", "1", "21412")]
        public void Get_node_for_scorecard_with_desc(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Resource<ScorecardNodeDto>("nodes");

            var dto = resource.Get(nodeId, "descriptions");
            Assert.That(dto.Name, Is.EqualTo("Bostadsbyggnadstakten ska vara hög"));
            Assert.That(dto.DescriptionFields.Count, Is.EqualTo(1));

        }

        [TestCase("1", "1", "21412")]
        public void Get_node_for_scorecard_with_keywords(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Resource<ScorecardNodeDto>("nodes");

            var dto = resource.Get(nodeId, "descriptions,keywords");
            Assert.That(dto.Name, Is.EqualTo("Bostadsbyggnadstakten ska vara hög"));
            Assert.That(dto.Keywords, Is.Not.Null);
        }



        // Stadens soliditet
        [TestCase("1", "1", "26")]
        public void Put_name_for_node(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Resource<ScorecardNodeDto>("nodes");

            var dto = resource.Get(nodeId);
            Assert.That(dto.Name, Is.StringStarting("Stadens soliditet"));
            Assert.That(dto.Scorecard.Name, Is.EqualTo("Verksamhetsplan"));
            Assert.That(dto.ScorecardColumn.Name, Is.EqualTo("Mätetal"));
            Assert.That(dto.Department.Id, Is.EqualTo(departmentId));

            var generic = "Stadens soliditet " + DateTime.Now.ToString("T");

            dto.Name = generic;
            dto = resource.Put(dto);
            Assert.That(dto.Name, Is.EqualTo(generic));
        }

        // Stadens soliditet
        [TestCase("1", "1", "26")]
        public void Get_name_for_node(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Resource<ScorecardNodeDto>("nodes");

            var dto = resource.Get(nodeId);
            Assert.That(dto.Name, Is.StringStarting("Stadens soliditet"));
            Assert.That(dto.Scorecard.Name, Is.EqualTo("Verksamhetsplan"));
            Assert.That(dto.ScorecardColumn.Name, Is.EqualTo("Mätetal"));
            Assert.That(dto.Department.Id, Is.EqualTo(departmentId));

        }


    }
}