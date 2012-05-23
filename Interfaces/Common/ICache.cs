using System;

namespace Illumination.Core.Interfaces.Common
{
    public interface ICache
    {
        object Get(string key);
        T GetOrStore<T>(string key, Func<T> generator, int timeoutSeconds);
        void Insert(string key, object value, System.Web.Caching.CacheDependency  dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration );
    }
}
