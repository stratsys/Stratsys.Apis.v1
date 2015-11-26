using System.Collections.Generic;

namespace Stratsys.Apis.v1.Dtos.StratsysApps
{
    public class DashboardDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<ReportingListDto> ReportingLists { get; set; }
        public IList<ReportListDto> ReportLists { get; set; }
    }
}