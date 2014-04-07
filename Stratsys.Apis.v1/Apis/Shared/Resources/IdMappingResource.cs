using Stratsys.Apis.v1.Apis.Shared.Requests;
using Stratsys.Apis.v1.Dtos.Shared;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis.Shared.Resources
{
    public class IdMappingResource
    {
        private readonly IClientService m_service;

        public IdMappingResource(IClientService service)
        {
            m_service = service;
        }

        public FilterIdMappingsRequest Filter(
            string typeId,
            string externalId = null,
            string internalId = null)
        {
            return new FilterIdMappingsRequest(m_service, typeId, externalId, internalId);
        }

        public ListIdMappingTypesRequest ListAllTypes()
        {
            return new ListIdMappingTypesRequest(m_service);
        }

        public SaveOrUpdateIdMappingRequest SaveOrUpdate(IdMapping idMapping)
        {
            return new SaveOrUpdateIdMappingRequest(m_service, idMapping);
        }

        public SaveOrUpdateIdMappingRequest SaveOrUpdate(string mappingTypeId, string externalId, string internalId)
        {
            var idMapping = new IdMapping
            {
                InternalId = internalId,
                ExternalId = externalId,
                MappingTypeId = mappingTypeId
            };
            return new SaveOrUpdateIdMappingRequest(m_service, idMapping);
        }

        public DeleteIdMappingRequest Delete(string mappingTypeId, string externalId)
        {
            return new DeleteIdMappingRequest(m_service, mappingTypeId, externalId);
        }

        public GetIdMappingRequest Get(string mappingTypeId, string externalId)
        {
            return new GetIdMappingRequest(m_service, mappingTypeId, externalId);
        }
    }
}