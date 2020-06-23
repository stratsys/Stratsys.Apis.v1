using System.Collections.Generic;

namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class DocumentRootFolderDto
    {
        public IList<DocumentFolderDto> Folders { get; set; }
        public IList<DocumentInfoDto> Documents { get; set; }
    }

    public class DocumentFolderDto : DocumentRootFolderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}