using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace GeoDataSource.Extensions
{
    /// <summary>
    /// a simple abstraction above System.Net.ParallelWebClient
    /// we want to abstract so we can swap it to any other library in the future
    /// </summary>
    public class ParallelWebClient
    {
        private WebClient _client { get; set; }

        private WebHeaderCollection _responseHeaders;

        public WebHeaderCollection ResponseHeaders
        {
            get
            {
                if (_responseHeaders == null) _responseHeaders = _client.ResponseHeaders;
                return _responseHeaders;
            }
            set { _responseHeaders = value; }
        }

        public WebClientRequest Request { get; set; }

        public ParallelWebClient(WebClientRequest request)
        {
            Request = request;
        }

        public Task<byte[]> DownloadData(string address)
        {
            var wc = InitWebClient();
            return wc.DownloadDataTask(address);
        }

        private WebClient InitWebClient()
        {
            var wc = new WebClient();

            if (Request.Credentials != null) wc.Credentials = Request.Credentials;
            if (Request.Headers != null) wc.Headers = Request.Headers;
            if (Request.Proxy != null) wc.Proxy = Request.Proxy;
            if (Request.UseDefaultCredentials) wc.UseDefaultCredentials = Request.UseDefaultCredentials;

            _client = wc;

            return wc;
        }

        public Task<string> DownloadString(string address)
        {
            var wc = InitWebClient();
            return wc.DownloadStringTask(address).ContinueWith(t =>
                {
                    ResponseHeaders = wc.ResponseHeaders;
                    return t.Result;
                });
        }


        public Task DownloadFileTask(string address, string fileName)
        {
            var wc = InitWebClient();
            return wc.DownloadFileTask(address, fileName).ContinueWith(t =>
                {
                    ResponseHeaders = wc.ResponseHeaders;
                    return t;
                });
        }

        public Task<Stream> OpenReadTask(string address, string method = "GET")
        {
            var wc = InitWebClient();
            return wc.OpenReadTask(address).ContinueWith(t =>
                {
                    ResponseHeaders = wc.ResponseHeaders;
                    return t.Result;
                });
        }

        public Task<Stream> OpenWriteTask(string address, string method)
        {
            var wc = InitWebClient();
            var result = wc.OpenWriteTask(address, method).ContinueWith(t =>
                {
                    ResponseHeaders = wc.ResponseHeaders;
                    return t.Result;
                });
            return result;
        }

        public Task<byte[]> UploadDataTask(string address, string method, byte[] data)
        {
            var wc = InitWebClient();
            return wc.UploadDataTask(address, method, data).ContinueWith(t =>
                {
                    ResponseHeaders = wc.ResponseHeaders;
                    return t.Result;
                });
        }

        public Task<byte[]> UploadFileTask(string address, string method, string fileName)
        {
            var wc = InitWebClient();
            return wc.UploadFileTask(address, method, fileName).ContinueWith(t =>
                {
                    ResponseHeaders = wc.ResponseHeaders;
                    return t.Result;
                });
        }

        public Task<string> UploadStringTask(string address, string method, string data)
        {
            var wc = InitWebClient();
            return wc.UploadStringTask(address, method, data).ContinueWith(t =>
                {
                    ResponseHeaders = wc.ResponseHeaders;
                   return t.Result;
                });
        }
    }
}