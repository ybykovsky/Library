using System;
using System.Security.Principal;
using Microsoft.AspNet.Identity;

namespace Library.Domain
{
    public static class IdentityExt
    {
        public static Guid GetGuidUserId(this IIdentity identity)
        {
            return identity.GetUserId().ToGuid();
        }
    }
}
