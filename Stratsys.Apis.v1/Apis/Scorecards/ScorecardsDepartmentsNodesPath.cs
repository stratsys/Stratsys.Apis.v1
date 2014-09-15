using Stratsys.Apis.v1.Apis.Scorecards.Resources;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards
{
    public class ScorecardsDepartmentsNodesPath
    {
        private readonly StratsysAuthentication m_authentication;
        private readonly Path m_path;
        private readonly IClientService m_descriptionFieldValueService;
        private readonly IClientService m_nodeKeywordService;

        public ScorecardsDepartmentsNodesPath(StratsysAuthentication authentication,
            Path path)
        {
            m_authentication = authentication;
            m_path = path;
            m_descriptionFieldValueService = new GenericService(authentication, path.Descriptionfields);
            m_nodeKeywordService = new GenericService(authentication, path.Keywords);
        }

        public DescriptionFieldValueResource DescriptionFields
        {
            get { return new DescriptionFieldValueResource(m_descriptionFieldValueService); }
        }

        public NodeKeywordResource Keywords
        {
            get { return new NodeKeywordResource(m_nodeKeywordService); }
        }

    }
}