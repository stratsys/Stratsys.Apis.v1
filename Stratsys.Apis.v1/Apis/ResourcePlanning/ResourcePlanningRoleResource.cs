using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.ResourcePlanning
{
    public class ResourcePlanningRoleResource<T>
    {
        private readonly GenericResource<T> m_genericResource;

        public ResourcePlanningRoleResource(IClientService service)
        {
            m_genericResource = new GenericResource<T>(service);
        }

        public ListRequest<T> List()
        {
            return m_genericResource.List();
        }
    }
}