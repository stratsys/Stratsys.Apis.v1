using NUnit.Framework;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Kpis
{
    public class KpiColumnServiceUT : BaseTest
    {
        [TestCase("1234567", "1")]
        public void When_filtering_on_kpiColumns_and_kpi_does_not_exist_Should_fail(string kpiId, string departmentIdFilter)
        {
            var stratsysApiMetadata = Api.KpiColumns.Filter(kpiId, departmentIdFilter).Fetch();
            Assert.That(stratsysApiMetadata.Success, Is.False);
            Assert.That(stratsysApiMetadata.Message, Is.EqualTo("Kpi undefined: 1234567 ('Department: 1')"));
            Assert.That(stratsysApiMetadata.Result, Is.Null);
        }

        [TestCase("16365", "1", 5)]
        public void When_filtering_on_kpiColumns_by_departmentId_Should_get_filtered_kpiColumns(string kpiId, string departmentIdFilter, int expectedNumberOfKpiColumns)
        {
            var kpiColumns = Api.KpiColumns.Filter(kpiId, departmentIdFilter).Fetch().Result;
            Assert.That(kpiColumns.Count, Is.EqualTo(expectedNumberOfKpiColumns));
        }

        [TestCase("16365", "1", "män/pojkar", "18095", "Utfall Män/Pojkar", 1, "antal", "st")]
        [TestCase("16365", null, "män/pojkar", null, "Utfall Män/Pojkar", 1, "antal", "st")]
        public void When_filtering_on_kpiColumns_by_departmentId_and_name_for_consolidated_kpi_Should_get_filtered_kpiColumns(
            string kpiId, string departmentIdFilter, string nameFilter,
            string expectedId, string expectedName, int expectedIndex,
            string expectedPreFix, string expectedPostFix
            )
        {
            var kpiColumns = Api.KpiColumns.Filter(kpiId, departmentIdFilter, nameFilter).Fetch().Result;
            Assert.That(kpiColumns.Count, Is.EqualTo(1));
            var kpiColumn = kpiColumns[0];
            Assert.That(kpiColumn.Id, Is.EqualTo(expectedId));
            Assert.That(kpiColumn.KpiId, Is.EqualTo(kpiId));
            Assert.That(kpiColumn.Name, Is.EqualTo(expectedName));
            Assert.That(kpiColumn.Index, Is.EqualTo(expectedIndex));
            Assert.That(kpiColumn.Prefix, Is.EqualTo(expectedPreFix));
            Assert.That(kpiColumn.Postfix, Is.EqualTo(expectedPostFix));
        }
    }
}