# Selenium Example

Some bits and bobs with API and UI tests, contains a bit of magic to prevent webdrivers needlessly being created, includes a strategy for smoke testing

## Important

Ensure that the Selenium Webdriver NuGet package versions match the versions installed on your machine

## UI Tests

UI tests should be marked with the `browser-test` scenario tag, this will allow the WebDriver to be registered.

There's two ways to prevent browsers from needlessly being opened
1: Seperate UI and API scenarios and inherit the WebPage base class when writing UI logic
2: If for some reason feature files must contain both uI and API tests then whack the ensure the `api-test` scenario tag is added to the scenario

## Automatic UI Scenario Screenshot

Whilst the `ScreenshotScenarios` option is `true` in `./appsettings.json` screenshots will be saved automatically after a scenario has run, this will only happen for scenarios marked with the `browser-test` scenario tag

## Supported Webdrivers

UI interaction is written using the Selenium Webdrivers, currently the two support webdrivers are Chrome and Edge.

## API Tests

API tests should be marked with the `api-test`, this will prevent the WebDriver being needlessly registered
API tests are use written using the Flurl HTTP client Library

## Smoke Testing

Smoke testing is used to verify that the most important functionality is still working as expected, this can be done by adding the `smoke-test` scenario tag
Run `dotnet test --filter TestCategory=smoke-test` when running tests to exclude all other unit tests

## Further Notes

Specflow - https://specflow.org/  
Selenium - https://www.selenium.dev/  
Waiting in Selenium - https://www.browserstack.com/guide/wait-commands-in-selenium-webdriver  
Flurl HTTP client library - https://flurl.dev/  
Smoke testing - https://www.toolsqa.com/software-testing/smoke-testing/
