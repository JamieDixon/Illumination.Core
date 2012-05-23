using System;

namespace Illumination.Core.Factories
{
    public class UrlFactory : IUrlFactory
    {
        public Uri CreateInstance(string input)
        {
            return new Uri(input);
        }
    }
}
