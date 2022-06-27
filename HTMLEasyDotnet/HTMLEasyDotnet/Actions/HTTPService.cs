using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HTMLEasyDotnet.Actions
{
    public class HTTPService
    {
        private readonly string _url;

        public HTTPService(string url)
        {
            _url = url;
        }

        async public Task<string> GetAsyncHtml()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_url);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            return await httpClient.GetAsync(_url).Result.Content.ReadAsStringAsync();
        }
    }
}
