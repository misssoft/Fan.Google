using System.Net.Http;
using System.Threading.Tasks;

namespace SearchConsole.MozApi
{
    public class MozAuthService
    {

        private readonly string MozApiUrl = "http://lsapi.seomoz.com/linkscape/url-metrics/";

        private readonly string _requestStr;
        private readonly HttpClient _client;

        private readonly MozAuthenticator _authenticator;


        public MozAuthService()
        {
            _client = new HttpClient();
            _authenticator = new MozAuthenticator();
            _requestStr = _authenticator.getAnthenticationStr();
        }


        public Task<HttpResponseMessage> MozAuth(string url, string cols)
        {
            url = string.IsNullOrEmpty(url) ? "moz.com" : url;
            cols = string.IsNullOrEmpty(cols) ? "4" : cols;

            //var urlBytes = Encoding.UTF8.GetBytes(url);

            //string encodedUrl = Convert.ToBase64String(urlBytes);


            var requestUrl = MozApiUrl + url + "?" +
                 "Cols=" + cols + "&" + _requestStr;


            return _client.GetAsync(requestUrl);
        }

    }
}