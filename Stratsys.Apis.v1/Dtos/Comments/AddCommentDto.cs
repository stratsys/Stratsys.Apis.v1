namespace Stratsys.Apis.v1.Dtos.Comments
{
    public class AddCommentDto
    {
        public string UserId { get; set; }
        public string DepartmentId { get; set; }
        public string NodeId { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public bool? IsPeriodFinished { get; set; }
    }
}