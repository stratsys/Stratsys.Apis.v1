﻿using System.Collections.Generic;
using System.Net.Http;
using Stratsys.Core.Apis.Services;

namespace Stratsys.Apis.v1.Apis
{
    public class ListRequest<T> : StratsysClientRequest<IList<T>>
    {
        public ListRequest(IClientService service)
            : base(service)
        {
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override string RestPath
        {
            get { return ""; }
        }

        public IList<T> Result
        {
            get
            {
                var metadata = Fetch();
                if (!metadata.Success)
                {
                    throw new HttpRequestException(metadata.Message);
                }
                return metadata.Result;
            }
        }
    }
}