using Stratsys.Apis.v1.Dtos.Organization;

namespace Stratsys.Apis.v1.Dtos.Scorecards
{
    public class NodeExternalPageDto
    {
        public string UrlSuffix { get; set; }
        public ExternalPageDto ExternalPage { get; set; }
    }
}