using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Illumination.Core.Factories
{
    public class HttpContextFactory : IHttpContextFactory
    {
        private readonly object _lock = new object();
        private HttpContextBase _mockHttpContext;

        /// <summary>
        /// Access the HttpContext using the Abstractions.
        /// </summary>
        public HttpContextBase Current
        {
            get
            {
                lock (_lock)
                {
                    if (_mockHttpContext == null && HttpContext.Current != null)
                    {
                        return new HttpContextWrapper(HttpContext.Current);
                    }
                }

                return _mockHttpContext;
            }

            set
            {
                lock (_lock)
                {
                    _mockHttpContext = value;
                }
            }
        }
    }


}
