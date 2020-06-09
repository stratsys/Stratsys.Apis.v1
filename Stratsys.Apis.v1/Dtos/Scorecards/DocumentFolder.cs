using System.Collections.Generic;

namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class DocumentRootFolder
    {
        public IList<DocumentFolder> Folders { get; set; }
        public IList<DocumentInfo> Documents { get; set; }
    }

    public class DocumentFolder : DocumentRootFolder
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
    }
}