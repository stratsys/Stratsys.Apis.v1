namespace Stratsys.Apis.v1.Dtos.Kpis
{
    public class KpiDataDto
    {
        public string KpiId { get; set; }
        public string DepartmentId { get; set; }
        public string KpiColumnId { get; set; }
        public string KpiColumnName { get; set; }
        public int? KpiColumnIndex { get; set; }
        public string Date { get; set; }
        public double? Value { get; set; }
    }
}