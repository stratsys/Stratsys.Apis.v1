using System.Collections.Generic;

namespace Stratsys.Apis.v1.Dtos.Kpis
{
    public class KpiDto
    {
        public string Id { get; set; }        
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string PeriodicityId { get; set; }
        public IList<string> KpiColumnIds { get; set; }
    }

}