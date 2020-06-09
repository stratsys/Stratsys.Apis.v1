using System;

namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class DocumentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UploadedDate { get; set; }
        public string Url { get; set; }
    }
}