﻿namespace Stratsys.Apis.v1.Apis.Kpis
{
    public class KpiService : StratsysClientService
    {
        public KpiService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
            Kpis = new KpiResource(this);
        }

        public override string Controller
        {
            get { return "kpis"; }
        }

        public KpiResource Kpis { get; private set; }
    }
}