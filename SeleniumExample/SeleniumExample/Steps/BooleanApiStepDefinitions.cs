using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using SeleniumExample.Support.Configuration;

namespace SeleniumExample.Steps
{
    [Binding]
    public class BooleanApiStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private static string ApiResponseScenarioContextKey => "boolean-api-response";
    
        private readonly AppSettings _appSettings;
    
        public BooleanApiStepDefinitions(ScenarioContext scenarioContext, IOptions<AppSettings> options)
        {
            _scenarioContext = scenarioContext;
            _appSettings = options.Value;
        }

        private IFlurlRequest CreateBooleanApiRequest(bool passExpectedValue)
        {
            return _appSettings.BooleanApiUrl
                .AppendPathSegment($"/pass-expected/{passExpectedValue}")
                .AllowAnyHttpStatus();
        }
        
        [Given(@"the api is called with a passExpected value of true")]
        public async Task GivenTheApiIsCalledWithAPassExpectedValueOfTrue()
        {
            var apiRequest = CreateBooleanApiRequest(true);
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
            var apiRequest = CreateBooleanApiRequest(false);
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