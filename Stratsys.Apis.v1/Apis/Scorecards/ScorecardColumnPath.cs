using Stratsys.Apis.v1.Apis.Scorecards.Resources;

namespace Stratsys.Apis.v1.Apis.Scorecards
{
    public class ScorecardColumnPath
    {
        private GenericService m_service;

        public ScorecardColumnPath(StratsysAuthentication authentication, string id)
        {
            var controller = Path.ScorecardColumn(id).ResponsibilityRoles;
            m_service = new GenericService(authentication, controller);

        }

        public ScorecardColumnResponsibilityRolesResource ResponsibilityRoles
        {
            get
            {
                return new ScorecardColumnResponsibilityRolesResource(m_service);
            }
        }

    }
}