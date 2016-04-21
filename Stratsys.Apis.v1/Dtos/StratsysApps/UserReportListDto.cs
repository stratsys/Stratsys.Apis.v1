namespace Stratsys.Apis.v1.Dtos.StratsysApps
{
    public class UserReportListItemDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public DeadlineViewModelDto Deadline { get; set; }
        public string ReportPeriod { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public UserReportListItemProgressDto ReportProgress { get; set; }
    }

    public class UserReportListItemProgressDto
    {
        public double PercentageReady { get; set; }
        public double PercentageFinished { get; set; }
        public bool ShouldRender { get; set; }
        public bool ShouldShowBothReadyAndPassed { get; set; }
    }
}