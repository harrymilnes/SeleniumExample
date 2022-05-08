using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using SeleniumExample.Support.Configuration;

namespace SeleniumExample.ApiClients
{
    public class BooleanApiClient : IBooleanApiClient
    {
        private readonly AppSettings _appSettings;

        public BooleanApiClient(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public IFlurlRequest CreateBooleanApiRequest(bool passExpectedValue)
        {
            return _appSettings.BooleanApiUrl
                .AppendPathSegment($"/pass-expected/{passExpectedValue}")
                .AllowAnyHttpStatus();
        }
    }
}