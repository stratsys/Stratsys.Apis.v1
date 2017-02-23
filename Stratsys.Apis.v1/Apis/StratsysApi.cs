using System;
using Stratsys.Apis.v1.Apis.Activities.Resources;
using Stratsys.Apis.v1.Apis.Activities.Services;
using Stratsys.Apis.v1.Apis.Applications.Resources;
using Stratsys.Apis.v1.Apis.Applications.Services;
using Stratsys.Apis.v1.Apis.Comments.Resources;
using Stratsys.Apis.v1.Apis.Comments.Services;
using Stratsys.Apis.v1.Apis.Kpis.Resources;
using Stratsys.Apis.v1.Apis.Kpis.Services;
using Stratsys.Apis.v1.Apis.Organization.Resources;
using Stratsys.Apis.v1.Apis.Organization.Services;
using Stratsys.Apis.v1.Apis.ResourcePlanning;
using Stratsys.Apis.v1.Apis.Scorecards;
using Stratsys.Apis.v1.Apis.Scorecards.Resources;
using Stratsys.Apis.v1.Apis.Scorecards.Services;
using Stratsys.Apis.v1.Apis.Shared.Resources;
using Stratsys.Apis.v1.Apis.Shared.Services;
using Stratsys.Apis.v1.Apis.StratsysApps.Resources;
using Stratsys.Apis.v1.Apis.StratsysApps.Services;

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
            return new ScorecardsPath(m_authentication, id);
        }

        public ScorecardColumnResource ScorecardColumns
        {
            get { return new ScorecardColumnService(m_authentication).ScorecardColumns; }
        }

        public ScorecardColumnPath ScorecardColumn(string id)
        {
            return new ScorecardColumnPath(m_authentication, id);
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

        public ScorecardsDepartmentsNodesPath Node(string scorecardId, string departmentId, string nodeId)
        {
            var node = Path.Scorecard(scorecardId).Department(departmentId).Node(nodeId);
            return new ScorecardsDepartmentsNodesPath(m_authentication, node);
        }

        public DescriptionFieldResource DescriptionFields
        {
            get { return new DescriptionFieldService(m_authentication).DescriptionFields; }
        }

        public KeywordGroupResource KeywordGroups
        {
            get { return new KeywordGroupService(m_authentication).Keywordgroups; }
        }

        public ScorecardViewResource ScorecardViews
        {
            get { return new ScorecardViewService(m_authentication).ScorecardViews; }
        }

        public ApplicationResource Applications
        {
            get { return new ApplicationService(m_authentication).Applications; }
        }

        public VersionResource Versions
        {
            get { return new VersionService(m_authentication).Versions; }
        }

        public DashboardResource Dashboards
        {
            get { return new DasbhoardService(m_authentication).Dashboards; }
        }

        public ReportListResource ReportLists
        {
            get { return new ReportListService(m_authentication).ReportLists; }
        }

        public ExternalPageResource ExternalPages
        {
            get { return new ExternalPageService(m_authentication).ExternalPages; }
        }

        public ResourcePlanningService ResourcePlanning
        {
            get { return new ResourcePlanningService(m_authentication); }
        }
    }
}
