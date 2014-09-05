using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards
{
    public class ScorecardsDepartmentsPath
    {
        private readonly StratsysAuthentication m_authentication;
        private readonly Path m_path;

        public ScorecardsDepartmentsPath(StratsysAuthentication authentication,
            Path path)
        {
            m_authentication = authentication;
            m_path = path;
        }

        public ScorecardNodeResource Nodes
        {
            get { return new ScorecardNodeResource(new GenericService(m_authentication, m_path.Nodes)); }
        }

        public ScorecardsDepartmentsNodesPath Node(string id)
        {
            return new ScorecardsDepartmentsNodesPath(m_authentication, m_path.Node(id));
        }

    }
}