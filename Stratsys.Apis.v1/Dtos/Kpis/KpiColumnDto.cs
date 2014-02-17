namespace Stratsys.Apis.v1.Dtos.Kpis
{
    public class KpiColumnDto
    {
        public string Id { get; set; }
        public string KpiId { get; set; }
        public string Name { get; set; }
        public string Postfix { get; set; }
        public string Prefix { get; set; }
        public int Position { get; set; }
    }
}