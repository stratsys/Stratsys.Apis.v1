using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class DescriptionFieldValueServiceUT : BaseTest
    {
        [TestCase("1", "1", "16365")]
        [TestCase("1", "5", "16365")]
        public void Get_all_for_node(string scorecardId, string departmentId, string nodeId)
        {
            var dtos = Api.DescriptionFieldValues(scorecardId, departmentId, nodeId)
                .List()
                .Result;
            Assert.That(dtos.Count, Is.EqualTo(2));
        }

    }
}