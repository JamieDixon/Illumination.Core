using System;
using System.Web;
using Illumination.Core.Interfaces.Common;

namespace Illumination.Core.Factories
{
    public interface IUrlFactory: IFactoryBase<string, Uri>{}
    public interface IHttpContextFactory: IFactoryBase<HttpContextBase>
    {
        HttpContextBase Current { get; set; }
    }
}