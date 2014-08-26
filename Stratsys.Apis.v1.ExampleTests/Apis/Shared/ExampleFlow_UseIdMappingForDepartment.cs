using System.Linq;
using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Shared
{
    public class ExampleFlow_UseIdMappingForDepartment : ExternalCodeApiTest
    {
        private string MappingTypeId = "Department";

        [TestCase("Skol- och fritidsnämnden", "externalId_123")]
        public void SetIdMappingAndFindResourceWithExternalId(string departmentName, string externalId)
        {
            var internalId = GetInternalId(departmentName);
            SetIdMapping(externalId, internalId);

            AssertIdMappingIsSet(externalId, internalId);
            AssertCanFindIdMappingFromInternalId(externalId, internalId);
            AssertGetResourceWithExternalId(externalId, departmentName);

            RemoveIdMapping(externalId);
        }

        private string GetInternalId(string departmentName)
        {
            var department = Api.Departments.Filter(departmentName).Result;
            Assert.That(department.Count, Is.EqualTo(1));
            return department.Single().Id;
        }

        private void SetIdMapping(string externalId, string id)
        {
            Api.IdMappings.SaveOrUpdate(MappingTypeId, externalId, id).Fetch();
        }

        private void AssertIdMappingIsSet(string externalId, string internalId)
        {
            var idMapping = Api.IdMappings.Get(MappingTypeId, externalId).Fetch().Result;
            Assert.That(idMapping.ExternalId, Is.EqualTo(externalId));
            Assert.That(idMapping.InternalId, Is.EqualTo(internalId));
        }

        private void AssertCanFindIdMappingFromInternalId(string externalId, string internalId)
        {
            var idMappings = Api.IdMappings.Filter(MappingTypeId, internalId: internalId).Fetch().Result;
            Assert.That(idMappings.Count, Is.EqualTo(1));
            var idMapping = idMappings[0];
            Assert.That(idMapping.InternalId, Is.EqualTo(internalId));
            Assert.That(idMapping.ExternalId, Is.EqualTo(externalId));
        }

        private void AssertGetResourceWithExternalId(string externalId, string departmentName)
        {
            var department = Api.Departments.Get(externalId).Fetch().Result;
            Assert.That(department.Id, Is.EqualTo(externalId));
            Assert.That(department.Name, Is.EqualTo(departmentName));
        }

        private void RemoveIdMapping(string externalId)
        {
            var result = Api.IdMappings.Delete(MappingTypeId, externalId).Fetch();
        }
    }
}