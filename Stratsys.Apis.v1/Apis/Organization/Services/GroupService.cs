﻿using Stratsys.Apis.v1.Apis.Organization.Resources;

namespace Stratsys.Apis.v1.Apis.Organization.Services
{
    public class GroupService : StratsysClientService
    {
        public GroupService(StratsysAuthentication authentication)
            : base(authentication)
        {
            Groups = new GroupResource(this);
        }

        public override string Controller
        {
            get { return "groups"; }
        }

        public GroupResource Groups { get; private set; }
    }
}