using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Organizations
{
    public class GroupServiceUT : BaseTest
    {
        [TestCase(8)]
        public void Get_all_groups(int expectedCount)
        {
            var groups = Api.Groups.List().Fetch().Result;
            Assert.That(groups.Count, Is.EqualTo(expectedCount));
        }

        [TestCase("20", "Enhetsansvarig")]
        public void Get_group_by_id(string id, string name)
        {
            var group = Api.Groups.Get(id).Fetch().Result;
            Assert.That(group.Name, Is.EqualTo(name));
        }

    }
}