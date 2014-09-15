using System.Linq;
using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Shared
{
    public class ExampleFlow_UseIdMappingForDepartment : ExternalCodeApiTest
    {
        private const string MappingTypeId = "Department";
        private const string ExternalId = "externalId_123";

        protected override void SetUp()
        {
            RemoveIdMapping();
        }

        protected override void TearDown()
        {
            RemoveIdMapping();
        }

        [TestCase("Skol- och fritidsnämnden")]
        public void SetIdMappingAndFindResourceWithExternalId(string departmentName)
        {
            var internalId = GetInternalId(departmentName);
            SetIdMapping(internalId);

            AssertIdMappingIsSet(internalId);
            AssertCanFindIdMappingFromInternalId(internalId);
            AssertGetResourceWithExternalId(departmentName);
        }

        private string GetInternalId(string departmentName)
        {
            var department = Api.Departments.Filter(departmentName).Result;
            Assert.That(department.Count, Is.EqualTo(1));
            return department.Single().Id;
        }

        private void SetIdMapping(string id)
        {
            Api.IdMappings.SaveOrUpdate(MappingTypeId, ExternalId, id).Fetch();
        }

        private void AssertIdMappingIsSet(string internalId)
        {
            var idMapping = Api.IdMappings.Get(MappingTypeId, ExternalId).Fetch().Result;
            Assert.That(idMapping.ExternalId, Is.EqualTo(ExternalId));
            Assert.That(idMapping.InternalId, Is.EqualTo(internalId));
        }

        private void AssertCanFindIdMappingFromInternalId(string internalId)
        {
            var idMappings = Api.IdMappings.Filter(MappingTypeId, internalId: internalId).Fetch().Result;
            Assert.That(idMappings.Count, Is.EqualTo(1));
            var idMapping = idMappings[0];
            Assert.That(idMapping.InternalId, Is.EqualTo(internalId));
            Assert.That(idMapping.ExternalId, Is.EqualTo(ExternalId));
        }

        private void AssertGetResourceWithExternalId(string departmentName)
        {
            var department = Api.Departments.Get(ExternalId).Fetch().Result;
            Assert.That(department.Id, Is.EqualTo(ExternalId));
            Assert.That(department.Name, Is.EqualTo(departmentName));
        }

        private void RemoveIdMapping()
        {
            Api.IdMappings.Delete(MappingTypeId, ExternalId).Fetch();
        }
    }
}