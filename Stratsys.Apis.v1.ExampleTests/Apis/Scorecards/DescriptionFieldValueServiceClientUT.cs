using System;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class DescriptionFieldValueServiceClientUT : ClientBaseTest
    {

        [TestCase("1", "1", "16365")]
        [TestCase("1", "5", "16365")]
        public void Get_all_for_node(string scorecardId, string departmentId, string nodeId)
        {
            var dtos = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Path("nodes", nodeId)
                .Resource<DescriptionFieldValueDto>("descriptionfields")
                .List();

            Assert.That(dtos.Count, Is.EqualTo(2));
        }

        //Bostadsbyggnadstakten ska vara hög
        [TestCase("1", "1", "21412")]
        public void Get_node_for_scorecard(string scorecardId, string departmentId, string nodeId)
        {
            var dtos = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Path("nodes", nodeId)
                .Resource<DescriptionFieldValueDto>("descriptionfields")
                .List();
            Assert.That(dtos.Count, Is.EqualTo(1));
        }

        [TestCase("1", "1", "16365", "1")]
        [TestCase("1", "5", "16365", "2")]
        public void Get_one_for_node(string scorecardId, string departmentId, string nodeId, string descriptionFieldId)
        {
            var dto = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Path("nodes", nodeId)
                .Resource<DescriptionFieldValueDto>("descriptionfields")
                .Get(descriptionFieldId);

            Assert.That(dto.DescriptionField.Id, Is.EqualTo(descriptionFieldId));
        }

        //Arbetskraftens storlek 16-64 år
        [TestCase("1", "1", "16365", "1")]
        [TestCase("1", "5", "16365", "2")]
        [TestCase("1", "1", "16365", "4")]
        public void Put_one_for_node(string scorecardId, string departmentId, string nodeId, string descriptionFieldId)
        {
            var resource = Client
                .Path("scorecards", scorecardId)
                .Path("departments", departmentId)
                .Path("nodes", nodeId)
                .Resource<DescriptionFieldValueDto>("descriptionfields");

            var dto = resource.Get(descriptionFieldId);

            var generic = "Text " + DateTime.Now.ToString("T");

            dto.TextValue = generic;

            dto = resource.Put(dto);

            Assert.That(dto.TextValue, Is.EqualTo(generic));
        }
    }
}