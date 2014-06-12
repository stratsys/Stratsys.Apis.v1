using Stratsys.Apis.v1.Apis.Shared.Resources;

namespace Stratsys.Apis.v1.Apis.Shared.Services
{
    public class IdMappingService : StratsysClientService
    {
        public IdMappingService(StratsysAuthentication authentication)
            : base(authentication)
        {
            IdMappings = new IdMappingResource(this);
        }

        public override string Controller
        {
            get { return "idmappings"; }
        }

        public IdMappingResource IdMappings { get; private set; }
    }
}