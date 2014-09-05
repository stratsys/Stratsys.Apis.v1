using Stratsys.Apis.v1.Apis.Scorecards.Resources;
using Stratsys.Apis.v1.Dtos.Scorecards;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Scorecards
{
    public class ScorecardsDepartmentsNodesPath
    {
        private readonly StratsysAuthentication m_authentication;
        private readonly Path m_path;
        private readonly IClientService m_descriptionFieldValueService;

        public ScorecardsDepartmentsNodesPath(StratsysAuthentication authentication,
            Path path)
        {
            m_authentication = authentication;
            m_path = path;
            m_descriptionFieldValueService = new GenericService(authentication, path.Descriptionfields);
        }

        public DescriptionFieldValueResource DescriptionFields
        {
            get { return new DescriptionFieldValueResource(m_descriptionFieldValueService); }
        }

    }
}