using Stratsys.Apis.v1.Dtos.Activities;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class CreateSimpleActivityRequest : StratsysClientRequest<string>
    {
        private readonly SimpleActivityDto m_dto;

        public CreateSimpleActivityRequest(IClientService service, SimpleActivityDto dto) : base(service)
        {
            m_dto = dto;
        }

        public override string HttpMethod
        {
            get { return "POST"; }
        }

        public override object Body
        {
            get { return m_dto; }
        }

        public override string RestPath
        {
            get { return "simple"; }
        }
    }
}