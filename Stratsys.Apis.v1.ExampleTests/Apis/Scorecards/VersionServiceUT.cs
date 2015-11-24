using System.Collections.Generic;
using NUnit.Framework;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Scorecards
{
    public class VersionServiceUT : BaseTest
    {
        [Test]
        public void List()
        {
            var versions = Api.Versions.List().Fetch().Result;
            Assert.That(versions.Count, Is.EqualTo(2));

            var currentVersion = versions[0];
            Assert.That(currentVersion.Name, Is.EqualTo("2016"));
            Assert.That(currentVersion.Type, Is.EqualTo("current"));
            Assert.That(currentVersion.Id, Is.EqualTo("4"));

            var planningVersion = versions[1];
            Assert.That(planningVersion.Name, Is.EqualTo("Planning 2017"));
            Assert.That(planningVersion.Type, Is.EqualTo("planning"));
            Assert.That(planningVersion.Id, Is.EqualTo("5"));
        }

        [Test]
        public void Get()
        {
            var versionId = "4";

            var version = Api.Versions.Get(versionId).Fetch().Result;
            Assert.That(version.Name, Is.EqualTo("2016"));
            Assert.That(version.Type, Is.EqualTo("current"));
            Assert.That(version.Id, Is.EqualTo(versionId));
        }
    }
}