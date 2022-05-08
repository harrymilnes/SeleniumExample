using Flurl.Http;

namespace SeleniumExample.ApiClients
{
    public interface IBooleanApiClient
    {
        IFlurlRequest CreateBooleanApiRequest(bool passExpectedValue);
    }
}