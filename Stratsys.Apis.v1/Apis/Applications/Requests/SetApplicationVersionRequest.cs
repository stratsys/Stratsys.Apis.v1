using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Applications.Requests
{
    public class SetApplicationVersionRequest : StratsysClientRequest<string>
    {
        private readonly string m_versionId;

        public SetApplicationVersionRequest(IClientService service, string versionId) : base(service)
        {
            m_versionId = versionId;
        }

        public override string HttpMethod
        {
            get { return "PUT"; }
        }

        public override string RestPath
        {
            get { return "this/version/"+ m_versionId; }
        }
    }
}