using System.Collections.Generic;

namespace Stratsys.Apis.v1.Dtos.Comments
{
    public class CommentDto
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Text { get; set; }
        public string PeriodDate { get; set; }
        public string PostedDate { get; set; }
        public string LastUpdatedDate { get; set; }
        public string UserId { get; set; }
    }
}