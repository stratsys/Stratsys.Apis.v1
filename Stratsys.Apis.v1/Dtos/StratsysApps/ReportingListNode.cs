namespace Stratsys.Apis.v1.Dtos.StratsysApps
{
    public class ReportingListNode
    {
        public DeadlineViewModelDto Deadline { get; set; }
        public ActionViewModelDto Action { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string NodeId { get; set; }
        public string NodeName { get; set; }
        public string ScorecardId { get; set; }
        public string ScorecardName { get; set; }
        public string PeriodName { get; set; }

        public string NodeType { get; set; }
        public string ImageTooltip { get; set; }
        public string ImageUrl { get; set; }
        public string ReportNodeDialogUrl { get; set; }

        public class ActionViewModelDto
        {
            public string CssClass { get; set; }
            public string Text { get; set; }
        }
    }
}