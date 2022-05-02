# Selenium Example
Some bits and bobs with API and UI tests, contains a bit of magic to prevent webdrivers needlessly being created, includes a strategy for smoke testing.

## Important
Ensure that the Selenium Webdriver NuGet package versions match the versions installed on your machine.

## UI Tests
There's two ways to prevent browsers from needlessly being opened.
1: Seperate UI and API scenarios and inherit the WebPage base class when writing UI logic.
2: If for some reason scenarios must contain both UI and API tests then whack the `no-browser` tag above a scenario to prevent the WebDriver from being needlessly created.

### Supported Webdrivers
UI interaction is written using the Selenium Webdrivers, currently the two support webdrivers are Chrome and Edge.

### API Tests
API tests are use written using the Flurl HTTP client Library

### Smoke Testing
Smoke testing is used to verify that the most important functionality is still working as expected, this can be done by adding the `smoke-test` tag

Run `dotnet test --filter TestCategory=smoke-test` when running tests to exclude all other unit tests

## Further Notes
Specflow - https://specflow.org/
Selenium - https://www.selenium.dev/
Waiting in Selenium - https://www.browserstack.com/guide/wait-commands-in-selenium-webdriver
Flurl HTTP client library - https://flurl.dev/
Smoke testing - https://www.toolsqa.com/software-testing/smoke-testing/
