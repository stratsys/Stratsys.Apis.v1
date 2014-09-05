using System;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class DescriptionFieldValueServiceUT : BaseTest
    {

        [TestCase("1", "1", "16365")]
        [TestCase("1", "5", "16365")]
        public void Get_all_for_node(string scorecardId, string departmentId, string nodeId)
        {
            var dtos = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Node(nodeId)
                .DescriptionFields
                .List()
                .Result;

            Assert.That(dtos.Count, Is.EqualTo(2));
        }

        [TestCase("1", "1", "16365", "1")]
        [TestCase("1", "5", "16365", "2")]
        public void Get_one_for_node(string scorecardId, string departmentId, string nodeId,
            string descriptionFieldId)
        {
            var dto = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Node(nodeId)
                .DescriptionFields
                .Get(descriptionFieldId)
                .Result;

            Assert.That(dto.DescriptionField.Id, Is.EqualTo(descriptionFieldId));
        }

        //Arbetskraftens storlek 16-64 år
        [TestCase("1", "1", "16365", "1")]
        [TestCase("1", "5", "16365", "2")]
        [TestCase("1", "1", "16365", "4")]
        public void Put_one_for_node(string scorecardId, string departmentId, string nodeId,
            string descriptionFieldId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Node(nodeId)
                .DescriptionFields;

            var dto = resource.Get(descriptionFieldId).Result;

            var generic = "Text " + DateTime.Now.ToString("T");

            dto.TextValue = generic;

            var fetch = resource.Put(dto).Fetch();
            Assert.That(fetch.Success, fetch.Message);

            dto = fetch.Result;
            Assert.That(dto.TextValue, Is.EqualTo(generic));
        }

        // Stadens soliditet
        [TestCase("1", "1", "26")]
        public void Put_name_for_node_as_description_field(string scorecardId, string departmentId, string nodeId)
        {
            var generic = "Stadens soliditet " + DateTime.Now.ToString("T");
            var valueDto = new DescriptionFieldValueDto
            {
                TextValue = generic
            };
            var fetch = Api.Scorecard(scorecardId).Department(departmentId).Node(nodeId).DescriptionFields
                .Put(valueDto).Fetch();
            Assert.That(fetch.Success, fetch.Message);

            var dto = fetch.Result;
            Assert.That(dto.TextValue, Is.EqualTo(generic));

            var node = Api.Scorecard(scorecardId).Department(departmentId).Nodes.Get(nodeId).Result;
            Assert.That(node.Name, Is.EqualTo(generic));
        }
    }
}