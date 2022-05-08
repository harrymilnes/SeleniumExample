using Flurl.Http;

namespace SeleniumExample.ApiClients
{
    public interface ICounterApiClient
    {
        IFlurlRequest CreateCountApiRequest(int currentNumber);
    }
}