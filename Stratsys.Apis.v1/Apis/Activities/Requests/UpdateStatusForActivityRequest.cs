﻿using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class UpdateStatusForActivityRequest : StratsysClientRequest<string>
    {
        private readonly string m_id;
        private readonly string m_statusId;

        public UpdateStatusForActivityRequest(IClientService clientService, string id, string statusId)
            : base(clientService)
        {
            m_id = id;
            m_statusId = statusId;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override string RestPath
        {
            get { return string.Format("{0}/status/{1}", m_id, m_statusId); }
        }
    }
}