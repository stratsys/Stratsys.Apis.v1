﻿using Stratsys.Apis.v1.Apis.Activities.Requests;
using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Resources
{
    public class ActivityResource
    {
        private readonly IClientService m_service;

        public ActivityResource(IClientService service)
        {
            m_service = service;
        }

        public FilterActivitiesRequest Filter(
            string id = null,
            string departmentId = null,
            string name = null,
            string scorecardId = null,
            string statusId = null,
            string userId = null,
            string fields = null,
            bool onlySimple = false,
            bool excludeFinished = false
            )
        {
            return new FilterActivitiesRequest(m_service, id, departmentId, name, scorecardId, statusId, userId, fields, onlySimple, excludeFinished);
        }

        public UpdateStatusForActivityRequest UpdateStatus(UpdateStatusDto updateStatusDto)
        {
            return new UpdateStatusForActivityRequest(m_service, updateStatusDto);
        }

        public GetStatusForActivityRequest GetStatus(string activityId, string departmentId = null)
        {
            return new GetStatusForActivityRequest(m_service, activityId, departmentId);
        }
    }
}