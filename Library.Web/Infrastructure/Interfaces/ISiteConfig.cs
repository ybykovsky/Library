using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Web.Infrastructure.Interfaces
{
    public interface ISiteConfig
    {
        string UserContentUrl { get; }
        string UserContentPhysicalPath { get; }
    }
}