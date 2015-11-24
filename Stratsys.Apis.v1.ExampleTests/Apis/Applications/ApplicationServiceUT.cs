using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Applications
{
    public class ApplicationServiceUT : BaseTest
    {
        [Test]
        public void This()
        {
            var application = Api.Applications.This().Fetch().Result;
            Assert.That(application.Name, Is.EqualTo("Stratsys.Apis.v1"));
            Assert.That(application.VersionId, Is.EqualTo("4"));
        }

        [TestCase("4", "5")]
        public void SetVersion(string oldVersionId, string newVersionId)
        {
            var versionId = Api.Applications.SetVersion(newVersionId).Fetch().Result;
            Assert.That(versionId, Is.EqualTo(newVersionId));

            var application = Api.Applications.This().Fetch().Result;
            Assert.That(application.Name, Is.EqualTo("Stratsys.Apis.v1"));
            Assert.That(application.VersionId, Is.EqualTo(newVersionId));

            var result = Api.Applications.SetVersion(oldVersionId).Fetch().Result;
        }
    }
}