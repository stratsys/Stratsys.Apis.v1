using Stratsys.Apis.v1.Apis.Generics;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Activities.Requests
{
    public class SetSortOrderRequest : PutIdRequest<string>
    {
        private readonly double m_sortOrder;

        public SetSortOrderRequest(IClientService service, string nodeId, double sortOrder) : base(service, nodeId)
        {
            m_sortOrder = sortOrder;
        }

        public override string RestPath
        {
            get { return base.RestPath + "/sortorder/" + m_sortOrder; }
        }
    }
}