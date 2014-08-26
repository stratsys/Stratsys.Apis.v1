using System;
using Stratsys.Apis.v1.Apis.Activities.Resources;
using Stratsys.Apis.v1.Apis.Activities.Services;
using Stratsys.Apis.v1.Apis.Comments.Resources;
using Stratsys.Apis.v1.Apis.Comments.Services;
using Stratsys.Apis.v1.Apis.Gadgets.Resources;
using Stratsys.Apis.v1.Apis.Gadgets.Services;
using Stratsys.Apis.v1.Apis.Kpis.Resources;
using Stratsys.Apis.v1.Apis.Kpis.Services;
using Stratsys.Apis.v1.Apis.Organization.Resources;
using Stratsys.Apis.v1.Apis.Organization.Services;
using Stratsys.Apis.v1.Apis.Scorecards;
using Stratsys.Apis.v1.Apis.Scorecards.Resources;
using Stratsys.Apis.v1.Apis.Scorecards.Services;
using Stratsys.Apis.v1.Apis.Shared.Resources;
using Stratsys.Apis.v1.Apis.Shared.Services;
using Stratsys.Apis.v1.Dtos.Scorecards;

namespace Stratsys.Apis.v1.Apis
{
    public class StratsysApi
    {
        private StratsysAuthentication m_authentication;

        [Obsolete("Use other constructor.")]
        public StratsysApi(string clientId, string clientSecret)
            : this(new ServiceAccountBasicAuthentication(clientId, clientSecret))
        {
            m_authentication = new ServiceAccountBasicAuthentication(clientId, clientSecret);
        }

        public StratsysApi(StratsysAuthentication authentication)
        {
            m_authentication = authentication;
        }

        public void SetAuthentication(StratsysAuthentication authentication)
        {
            m_authentication = authentication;
        }

        public CommentResource Comments
        {
            get { return new CommentService(m_authentication).Comments; }
        }

        public KpiResource Kpis
        {
            get { return new KpiService(m_authentication).Kpis; }
        }

        public KpiColumnResource KpiColumns
        {
            get { return new KpiColumnService(m_authentication).KpiColumns; }
        }

        public KpiDataResource KpiData
        {
            get { return new KpiDataService(m_authentication).KpiData; }
        }

        public DepartmentResource Departments
        {
            get { return new DepartmentService(m_authentication).Departments; }
        }

        public GroupResource Groups
        {
            get { return new GroupService(m_authentication).Groups; }
        }

        public UserResource Users
        {
            get { return new UserService(m_authentication).Users; }
        }

        public ScorecardResource Scorecards
        {
            get { return new ScorecardService(m_authentication).Scorecards; }
        }

        public ScorecardsPath Scorecard(string id)
        {
            { return new ScorecardsPath(m_authentication, id); }
        }

        //public IDepartmentScorecardNodeResource Scorecard(string id)
        //{
        //    { return new ScorecardNodeService(m_authentication).Scorecard(id); }
        //}

        public ScorecardColumnResource ScorecardColumns
        {
            get { return new ScorecardColumnService(m_authentication).ScorecardColumns; }
        }

        public GoalResource Goals
        {
            get { return new GoalService(m_authentication).Goals; }
        }

        public ActivityResource Activities
        {
            get { return new ActivityService(m_authentication).Activities; }
        }

        public StatusResource Statuses
        {
            get { return new StatusService(m_authentication).Statuses; }
        }

        public PeriodicityResource Periodicities
        {
            get { return new PeriodicityService(m_authentication).Periodicities; }
        }

        public AuthorizationResource Authorizations
        {
            get { return new AuthorizationService(m_authentication).Authorizations; }
        }

        public ReportingListResource ReportingLists
        {
            get { return new ReportingListService(m_authentication).ReportingLists; }
        }

        public IdMappingResource IdMappings
        {
            get { return new IdMappingService(m_authentication).IdMappings; }
        }

        public ResponsibilityRoleResource ResponsibilityRoles
        {
            get { return new ResponsibilityRoleService(m_authentication).ResponsibilityRoles; }
        }

        public NodeResponsibleResource NodeResponsibles
        {
            get { return new NodeResponsibleService(m_authentication).NodeResponsibles; }
        }

        public DescriptionFieldResource DescriptionFields
        {
            get { return new DescriptionFieldService(m_authentication).DescriptionFields; }
        }

        public DescriptionFieldValueResource DescriptionFieldValues(
            string scorecardId, string departmentId, string nodeId)
        {
            return new DescriptionFieldValueService(m_authentication, scorecardId, departmentId, nodeId).DescriptionFieldsValue;
        }

        public KeywordGroupResource KeywordGroups
        {
            get { return new KeywordGroupService(m_authentication).Keywordgroups; }
        }


    }
}
