using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class ScorecardNodeServiceUT : ClientBaseTest
    {
        //Arbetskraftens storlek 16-64 år
        [TestCase("1", "1", "16365")]
        [TestCase("1", "5", "16365")]
        public void Get_all_for_node(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;

            var dto = resource.Get(nodeId).Result;
            Assert.That(dto.Name, Is.EqualTo("Arbetskraftens storlek 16-64 år"));
            Assert.That(dto.Scorecard.Name, Is.EqualTo("Verksamhetsplan"));
            Assert.That(dto.ScorecardColumn.Name, Is.EqualTo("Mätetal"));
            Assert.That(dto.Department.Id, Is.EqualTo(departmentId));
        }

        //Verksamhetsplan
        [TestCase("1", "1", 47)]
        public void Get_all_for_scorecard(string scorecardId, string departmentId, int count)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;
            var dtos = resource.List().Result;
            Assert.That(dtos.Count, Is.EqualTo(count));
            foreach (var dto in dtos)
            {
                Assert.That(dto.Name, Is.Not.Null);
                Assert.That(dto.Scorecard, Is.Not.Null);
                Assert.That(dto.Scorecard.Id, Is.Not.Null);
                Assert.That(dto.Scorecard.Name, Is.Not.Null);
                Assert.That(dto.ScorecardColumn, Is.Not.Null);
                if (dto.ScorecardColumn.Index > 0)
                {
                    Assert.That(dto.ParentId, Is.Not.Null);
                }
                Assert.That(dto.ScorecardColumn.Name, Is.Not.Null);
                Assert.That(dto.ScorecardColumn.Definition, Is.Not.Null);
                Assert.That(dto.ScorecardColumn.NodeType, Is.Not.Null);
                Assert.That(dto.ScorecardColumn.ScorecardId, Is.Not.Null);
                Assert.That(dto.Department, Is.Not.Null);
                Assert.That(dto.Department.Id, Is.Not.Null);
                Assert.That(dto.Department.Name, Is.Not.Null);
                Assert.That(dto.Department.ShortName, Is.Not.Null);
            }
        }

        //Verksamhetsplan
        [TestCase("1", "1", 47)]
        public void Get_all_for_scorecard_filter(string scorecardId, string departmentId, int count)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;
            var dtos = resource.Filter().Result;
            Assert.That(dtos.Count, Is.EqualTo(count));
            foreach (var dto in dtos)
            {
                Assert.That(dto.Name, Is.Not.Null);
                Assert.That(dto.Scorecard, Is.Not.Null);
                Assert.That(dto.Scorecard.Id, Is.Not.Null);
                Assert.That(dto.Scorecard.Name, Is.Not.Null);
                Assert.That(dto.ScorecardColumn, Is.Not.Null);
                if (dto.ScorecardColumn.Index > 0)
                {
                    Assert.That(dto.ParentId, Is.Not.Null);
                }
                Assert.That(dto.ScorecardColumn.Name, Is.Not.Null);
                Assert.That(dto.ScorecardColumn.Definition, Is.Not.Null);
                Assert.That(dto.ScorecardColumn.NodeType, Is.Not.Null);
                Assert.That(dto.ScorecardColumn.ScorecardId, Is.Not.Null);
                Assert.That(dto.Department, Is.Not.Null);
                Assert.That(dto.Department.Id, Is.Not.Null);
                Assert.That(dto.Department.Name, Is.Not.Null);
                Assert.That(dto.Department.ShortName, Is.Not.Null);
            }
        }

        //Bostadsbyggnadstakten ska vara hög
        [TestCase("1", "1", "21412")]
        public void Get_node_for_scorecard(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;

            var dto = resource.Get(nodeId).Result;
            Assert.That(dto.Name, Is.EqualTo("Bostadsbyggnadstakten ska vara hög"));
            Assert.That(dto.DescriptionFields, Is.Null);
            Assert.That(dto.Keywords, Is.Null);
            Assert.That(dto.Responsibles, Is.Null);
        }

        //Bostadsbyggnadstakten ska vara hög
        [TestCase("1", "1", "21412")]
        public void Get_node_for_scorecard_with_desc(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;

            var dto = resource.Get(nodeId, "descriptionfields").Result;
            Assert.That(dto.Name, Is.EqualTo("Bostadsbyggnadstakten ska vara hög"));
            Assert.That(dto.DescriptionFields.Count, Is.EqualTo(1));

        }

        //Bostadsbyggnadstakten ska vara hög
        [TestCase("1", "1", "21412")]
        public void Get_node_for_scorecard_with_keywords(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;

            var dto = resource.Get(nodeId, "keywords").Result;
            Assert.That(dto.Name, Is.EqualTo("Bostadsbyggnadstakten ska vara hög"));
            Assert.That(dto.Keywords, Is.Not.Null);
        }

        //Bostadsbyggnadstakten ska vara hög
        [TestCase("1", "1", "21412")]
        public void Get_node_for_scorecard_with_responsibles(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;

            var dto = resource.Get(nodeId, "responsibles").Result;
            Assert.That(dto.Name, Is.EqualTo("Bostadsbyggnadstakten ska vara hög"));
            Assert.That(dto.Responsibles, Is.Not.Null);
        }

        //Genomföra utvecklingssamtal
        [TestCase("1", "16", "7608")]
        public void Get_node_for_scorecard_with_node_type_specific_content(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;

            var dto = resource.Get(nodeId, "nodetypespecific").Result;
            Assert.That(dto.Name, Is.EqualTo("Genomföra utvecklingssamtal"));
            Assert.That(dto.CurrentStatus, Is.Not.Null);
            Assert.That(dto.Statuses, Is.Not.Null);
        }

        // Stadens soliditet
        [TestCase("1", "1", "26")]
        public void Get_name_for_node(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;

            var dto = resource.Get(nodeId).Result;
            Assert.That(dto.Name, Is.StringStarting("Stadens soliditet"));
            Assert.That(dto.Scorecard.Name, Is.EqualTo("Verksamhetsplan"));
            Assert.That(dto.ScorecardColumn.Name, Is.EqualTo("Mätetal"));
            Assert.That(dto.Department.Id, Is.EqualTo(departmentId));

        }

        // Stadens soliditet
        [TestCase("1", "1", "26")]
        public void Put_name_for_node(string scorecardId, string departmentId, string nodeId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;

            var valueDto = resource.Get(nodeId).Result;

            var generic = "Stadens soliditet " + DateTime.Now.ToString("T");
            valueDto.Name = generic;

            var fetch = resource.Put(valueDto).Fetch();
            Assert.That(fetch.Success, fetch.Message);
            //var id = fetch.Result;

            //Assert.That(id, Is.EqualTo(nodeId));

            var node = resource.Get(nodeId).Result;
            Assert.That(node.Name, Is.EqualTo(generic));
        }

        // Stadens soliditet
        [TestCase("1", "1", "26", 12.4)]
        public void Set_sortorder_for_node(string scorecardId, string departmentId, string nodeId, double sortOrder)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;
            
            var fetch = resource.SetSortOrder(nodeId, sortOrder).Fetch();
            Assert.That(fetch.Success, fetch.Message);

            var node = resource.Get(nodeId).Result;
            Assert.That(node.SortOrder, Is.EqualTo(sortOrder));
        }

        // Api playground
        [TestCase("28", "2")]
        public void Post_node(string scorecardId, string departmentId)
        {
            var resource = Api
                .Scorecard(scorecardId)
                .Department(departmentId)
                .Nodes;

            var columns = GetScorecardColumns(scorecardId);
            var postNodeDtos = columns.Select(column => new PostNodeDto
            {
                Name = column.Name + " " + DateTime.Now.ToString("T"),
                ScorecardColumnId = column.Id
            });

            //build small list of nodes
            var parentId = resource.GetRoot().Result.Id;
            foreach (var nodeDto in postNodeDtos)
            {
                nodeDto.ParentId = parentId;
                var fetch = resource.Post(nodeDto).Fetch();
                Assert.That(fetch.Success, fetch.Message);

                parentId = fetch.Result;
            }
        }

        private IEnumerable<ScorecardColumnDto> GetScorecardColumns(string scorecardId)
        {
            var fetch = Api.Scorecard(scorecardId).Columns.Fetch();
            Assert.That(fetch.Success, fetch.Message);
            var columns = fetch.Result.Skip(1);
            return columns;
        }
    }
}