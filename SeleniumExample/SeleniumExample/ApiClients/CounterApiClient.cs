using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using SeleniumExample.Support.Configuration;

namespace SeleniumExample.ApiClients
{
    public class CounterApiClient : ICounterApiClient
    {
        private readonly AppSettings _appSettings;

        public CounterApiClient(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public IFlurlRequest CreateCountApiRequest(int currentNumber)
        {
            return _appSettings.CounterApiUrl
                .AppendPathSegment($"/increment/{currentNumber}")
                .AllowAnyHttpStatus();
        }
    }
}