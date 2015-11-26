namespace Stratsys.Apis.v1.Dtos.StratsysApps
{
    public class UserReportListItemDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public DeadlineViewModelDto Deadline { get; set; }
        public string ReportPeriod { get; set; }
    }
}