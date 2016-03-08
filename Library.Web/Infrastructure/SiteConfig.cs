using Library.Web.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Library.Web.Infrastructure
{
    public class SiteConfig : ISiteConfig
    {
        public string UserContentUrl
        {
            get { return "~/UserContent"; }
        }

        public string UserContentPhysicalPath
        {
            get
            {
                return HostingEnvironment.MapPath(UserContentUrl);
            }
        }
    }
}