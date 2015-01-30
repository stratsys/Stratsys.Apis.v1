using System.Collections.Generic;
using Stratsys.Apis.v1.Apis.Scorecards.Resources;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.Apis.Scorecards
{
    public class ScorecardColumnPath
    {
        private GenericService m_service;
        private GenericService m_service2;

        public ScorecardColumnPath(StratsysAuthentication authentication, string id)
        {
            m_service = new GenericService(authentication, Path.ScorecardColumn(id).ResponsibilityRoles);
            m_service2 = new GenericService(authentication, Path.ScorecardColumn(id).Descriptionfields);
        }

        public ScorecardColumnResponsibilityRolesResource ResponsibilityRoles
        {
            get
            {
                return new ScorecardColumnResponsibilityRolesResource(m_service);
            }
        }

        public GenericResource<DescriptionFieldDto> DescriptionFields
        {
            get { return new GenericResource<DescriptionFieldDto>(m_service2);}
        }

    }
}