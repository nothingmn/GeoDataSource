using System.Net;

namespace GeoDataSource.Extensions
{
    public class WebClientRequest
    {
        public bool UseDefaultCredentials { get; set; }
        public IWebProxy Proxy { get; set; }
        public WebHeaderCollection Headers { get; set; }
        public ICredentials Credentials { get; set; }
    }
}
