using Flurl.Http;
using NUnit.Framework;
using SeleniumExample.ApiClients;

namespace SeleniumExample.Steps
{
    [Binding]
    public class BooleanApiStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private static string ApiResponseScenarioContextKey => "boolean-api-response";
        private readonly IBooleanApiClient _booleanApiClient;
        
        public BooleanApiStepDefinitions(ScenarioContext scenarioContext, IBooleanApiClient booleanApiClient)
        {
            _scenarioContext = scenarioContext;
            _booleanApiClient = booleanApiClient;
        }

        [Given(@"the api is called with a passExpected value of true")]
        public async Task GivenTheApiIsCalledWithAPassExpectedValueOfTrue()
        {
            var apiRequest = _booleanApiClient.CreateBooleanApiRequest(true);
            var flurlResponse = await apiRequest.PostAsync();
            _scenarioContext.Set(flurlResponse, ApiResponseScenarioContextKey);
        }

        [Then(@"the api response should be success")]
        public void ThenTheApiResponseShouldBeSuccess()
        {
            var apiResponse = _scenarioContext.Get<IFlurlResponse>(ApiResponseScenarioContextKey);
            Assert.AreEqual(200, apiResponse.StatusCode);
        }

        [Given(@"the api is called with a passExpected value of false")]
        public async Task GivenTheApiIsCalledWithAPassExpectedValueOfFalse()
        {
            var apiRequest = _booleanApiClient.CreateBooleanApiRequest(false);
            var flurlResponse = await apiRequest.PostAsync();
            _scenarioContext.Set(flurlResponse, ApiResponseScenarioContextKey);
        }

        [Then(@"the api response should be bad")]
        public void ThenTheApiResponseShouldBeBad()
        {
            var apiResponse = _scenarioContext.Get<IFlurlResponse>(ApiResponseScenarioContextKey);
            Assert.AreEqual(400, apiResponse.StatusCode);
        }
    }
}