namespace Stratsys.Apis.v1.Dtos.Comments
{
    public class UpdateCommentDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public bool? IsPeriodFinished { get; set; }
    }
}