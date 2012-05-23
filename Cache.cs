using System;
using System.Web;
using System.Web.Caching;
using Illumination.Core.Interfaces.Common;

namespace Illumination.Core
{
    public class Cache : ICache
    {
        public virtual object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }

        public T GetOrStore<T>(string key, Func<T> generator, int timeoutSeconds)
        {
            // TODO: Consider GZipping the content before putting in the cache (Like StackOverflow do)
            var result = Get(key);

            if (result == null)
            {
                Console.WriteLine("CacheExtensions.GetOrStore<T> : Executing fresh query");
                result = generator();

                if (timeoutSeconds > 0 && result != null)
                    {
                        Insert(key, result, null, DateTime.Now.AddSeconds(timeoutSeconds),
                                     System.Web.Caching.Cache.NoSlidingExpiration);
                    }
            }
            else
            {
                Console.WriteLine("CacheExtensions.GetOrStore<T> : Executing cached query");
            }
            return (T)result;
        }

        public void Insert(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            HttpRuntime.Cache.Insert(key, value, dependency, absoluteExpiration, slidingExpiration);
        }
    }
}
