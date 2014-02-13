using NUnit.Framework;
using Stratsys.Apis.v1.Apis.Kpis;
using Stratsys.Apis.v1.Tests;

namespace Stratsys.Apis.v1.ExampleTests.Apis.Kpis
{
    public class KpiColumnServiceUT :BaseTest
    {
        [TestCase("1234567", "1")]
        public void When_filtering_on_kpiColumns_and_kpi_does_not_exist_Should_fail(string kpiId, string departmentIdFilter)
        {
            var stratsysApiMetadata = KpiColumns.Filter(kpiId, departmentIdFilter).Fetch();
            Assert.That(stratsysApiMetadata.Success, Is.False);
            Assert.That(stratsysApiMetadata.Message, Is.EqualTo("Kpi undefined: 1234567 ('Department: 1')"));
            Assert.That(stratsysApiMetadata.Result, Is.Null);
        }

        [TestCase("16365", "1", 5)]
        public void When_filtering_on_kpiColumns_by_departmentId_Should_get_filtered_kpiColumns(string kpiId, string departmentIdFilter, int expectedNumberOfKpiColumns)
        {
            var kpiColumns = KpiColumns.Filter(kpiId, departmentIdFilter).Fetch().Result;
            Assert.That(kpiColumns.Count, Is.EqualTo(expectedNumberOfKpiColumns));
        }

        [TestCase("16365", "1", "kvinnor/flickor", "18094", "Utfall Kvinnor/Flickor", 0)]
        public void When_filtering_on_kpiColumns_by_departmentId_and_name_Should_get_filtered_kpiColumns(
            string kpiId, string departmentIdFilter, string nameFilter, 
            string expectedId, string expectedName, int expectedPosition)
        {
            var kpiColumns = KpiColumns.Filter(kpiId, departmentIdFilter, nameFilter).Fetch().Result;
            Assert.That(kpiColumns.Count, Is.EqualTo(1));
            var kpiColumn = kpiColumns[0];
            Assert.That(kpiColumn.Id, Is.EqualTo(expectedId));
            Assert.That(kpiColumn.KpiId, Is.EqualTo(kpiId));
            Assert.That(kpiColumn.Name, Is.EqualTo(expectedName));
            Assert.That(kpiColumn.Position, Is.EqualTo(0));
        }

        private KpiColumnResource KpiColumns
        {
            get
            {
                return new KpiColumnService(ClientId, ClientSecret).KpiColumns;
            }
        }
    }
}