using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Shared
{
    public class IdMappingServiceUT : ExternalCodeApiTest
    {
        protected static readonly string[] MappingTypes =
        {
            "User",
            "Department",
            "Keyword",
            "Column",
            "KpiTemplate",
            "Group",
            "KeywordGroup",
            "Role",
            "Status",
            "ReportTableFilter",
            "Node",
            "Periodicity",
            "KpiGenerator"
        };

        [Test]
        public void Get_all_mappingTypes()
        {
            var mappingTypes = Api.IdMappings.ListAllTypes().Result;
            foreach (var mappingType in mappingTypes)
            {
                Assert.That(MappingTypes, Has.Member(mappingType));
            }
        }

        [Test, TestCaseSource("MappingTypes")]
        public void Delete_all_mappings(string mappingType)
        {
            var idMappings = Api.IdMappings.Filter(mappingType).Result;
            foreach (var mapping in idMappings)
            {
                var result = Api.IdMappings.Delete(mapping.MappingTypeId, mapping.ExternalId).Fetch();
                Assert.That(result, Has.Message.Null);
            }
        }

        [Test, TestCaseSource("MappingTypes")]
        public void Get_all_mappings(string mappingType)
        {
            var externalCodes = Api.IdMappings.Filter(mappingType).Fetch().Result;
            Assert.That(externalCodes.Count, Is.EqualTo(0));
        }

        [TestCase("User", "externalId_user_123", "2")]
        [TestCase("Department", "externalId_department_123", "2")]
        [TestCase("Keyword", "externalId_keyword_123", "2")]
        [TestCase("Column", "externalId_column_123", "2")]
        [TestCase("KpiTemplate", "externalId_kpiTemplate_123", "1")]
        [TestCase("Group", "externalId_group_123", "2")]
        [TestCase("KeywordGroup", "externalId_keywordgroup_123", "1")]
        [TestCase("Role", "externalId_role_123", "3")]
        [TestCase("Status", "externalId_status_123", "3")]
        [TestCase("ReportTableFilter", "externalId_reporttablefilter_123", "3")]
        [TestCase("Node", "externalId_kpi_123", "16365")]
        [TestCase("Periodicity", "externalId_periodicity_123", "1")]
        public void Set_mapping(string mappingType, string externalId, string internalId)
        {
            var result = Api.IdMappings.SaveOrUpdate(mappingType, externalId, internalId).Fetch().Result;
            Assert.That(result, Is.True);

            var idMapping = Api.IdMappings.Get(mappingType, externalId).Fetch().Result;
            Assert.That(idMapping.MappingTypeId, Is.EqualTo(mappingType));
            Assert.That(idMapping.ExternalId, Is.EqualTo(externalId));
            Assert.That(idMapping.InternalId, Is.EqualTo(internalId));

            Api.IdMappings.Delete(mappingType, externalId).Fetch();
        }

        [TestCase("Department", "externalId_123", "2")]
        public void Set_mapping_for_existing_mapped_external_id_Returns_false(string mappingType, string externalId, string internalId)
        {
            Api.IdMappings.SaveOrUpdate(mappingType, externalId, internalId).Fetch();
            var result = Api.IdMappings.SaveOrUpdate(mappingType, externalId, internalId).Fetch().Result;
            Assert.That(result, Is.False);
            
            Api.IdMappings.Delete(mappingType, externalId).Fetch();
        }
        
        [TestCase("Department", "externalId_123", "2")]
        public void Set_mapping_for_existing_mapped_internal_id_Returns_false(string mappingType, string externalId, string internalId)
        {
            Api.IdMappings.SaveOrUpdate(mappingType, externalId, internalId).Fetch();
            var result = Api.IdMappings.SaveOrUpdate(mappingType, externalId, internalId).Fetch().Result;
            Assert.That(result, Is.False);

            Api.IdMappings.Delete(mappingType, externalId).Fetch();
        }

        [TestCase("Department", "externalId_123", "123467")]
        public void Set_mapping_for_non_existing_internal_id_Fails(string mappingType, string externalId, string internalId)
        {
            var stratsysApiMetadata = Api.IdMappings.SaveOrUpdate(mappingType, externalId, internalId).Fetch();
            Assert.That(stratsysApiMetadata.Success, Is.False);
            Assert.That(stratsysApiMetadata.Message, Is.EqualTo("IdMapping undefined: 123467 ('Department undefined')"));
        }
    }
}