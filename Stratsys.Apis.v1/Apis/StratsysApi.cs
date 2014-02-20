﻿using Stratsys.Apis.v1.Apis.Comments.Resources;
using Stratsys.Apis.v1.Apis.Comments.Services;
using Stratsys.Apis.v1.Apis.Kpis.Resources;
using Stratsys.Apis.v1.Apis.Kpis.Services;
using Stratsys.Apis.v1.Apis.Organization.Resources;
using Stratsys.Apis.v1.Apis.Organization.Services;
using Stratsys.Apis.v1.Apis.Scorecards.Resources;
using Stratsys.Apis.v1.Apis.Scorecards.Services;
using Stratsys.Apis.v1.Apis.Shared.Resources;
using Stratsys.Apis.v1.Apis.Shared.Services;

namespace Stratsys.Apis.v1.Apis
{
    public class StratsysApi
    {
        public StratsysApi(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        protected string ClientId { get; set; }
        protected string ClientSecret { get; set; }

        public CommentResource Comments
        {
            get { return new CommentService(ClientId, ClientSecret).Comments; }
        }

        public KpiResource Kpis
        {
            get { return new KpiService(ClientId, ClientSecret).Kpis; }
        }

        public KpiColumnResource KpiColumns
        {
            get { return new KpiColumnService(ClientId, ClientSecret).KpiColumns; }
        }

        public KpiDataResource KpiData
        {
            get { return new KpiDataService(ClientId, ClientSecret).KpiData; }
        }

        public DepartmentResource Departments
        {
            get { return new DepartmentService(ClientId, ClientSecret).Departments; }
        }

        public ScorecardResource Scorecards
        {
            get { return new ScorecardService(ClientId, ClientSecret).Scorecards; }
        }

        public PeriodicityResource Periodicities
        {
            get { return new PeriodicityService(ClientId, ClientSecret).Periodicities; }
        }

        public AuthorizationResource Authorizations
        {
            get { return new AuthorizationService(ClientId, ClientSecret).Authorizations; }
        }

    }
}
