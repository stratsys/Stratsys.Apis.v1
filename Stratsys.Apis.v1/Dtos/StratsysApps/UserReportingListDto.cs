using System.Collections.Generic;

namespace Stratsys.Apis.v1.Dtos.StratsysApps
{
    public class UserReportingListDto
    {
        public bool ShowScorecardName { get; set; }
        public bool ShowAll { get; set; }
        public bool ShowPeriod { get; set; }
        public List<ReportingListNode> Nodes { get; set; }
    }
}