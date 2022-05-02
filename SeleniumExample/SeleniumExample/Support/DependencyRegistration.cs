using System.Reflection;
using Autofac;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using SeleniumExample.Support.Configuration;
using SeleniumExample.Support.Enums;
using SpecFlow.Autofac;

namespace SeleniumExample.Support
{
    public class DependencyRegistration
    {
        [ScenarioDependencies]
        public static void SetupScenarioDependencies(ContainerBuilder containerBuilder)
        {
            var configuration = BuildConfiguration();

            RegisterSpecflowBindings(containerBuilder);

            RegisterConfiguration(containerBuilder, configuration);
            
            RegisterWebDriver(configuration.GetValue<WebDriverBrowser>("WebDriverBrowser"), containerBuilder);
        }

        private static void RegisterSpecflowBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).SingleInstance();
        }

        private static void RegisterConfiguration(ContainerBuilder containerBuilder, IConfiguration configuration)
        {
            containerBuilder.Register(c => Options.Create(configuration.Get<AppSettings>()));
        }

        private static IConfiguration BuildConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("./appsettings.json");
        
            var configuration = configurationBuilder.Build();
            return configuration; 
        }
        
        private static void RegisterWebDriver(WebDriverBrowser webDriverBrowser, ContainerBuilder containerBuilder)
        {
            var webPages = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsAssignableTo<Webpage.Webpage>()).ToArray();
            containerBuilder.RegisterTypes(webPages).SingleInstance().OnActivated(SetWebDriverInstance);
            containerBuilder.Register(x => WebDriverFactory.AddWebDriver(webDriverBrowser)).As<IWebDriver>().SingleInstance();
        }

        private static void SetWebDriverInstance(IActivatedEventArgs<object> activatedEventArgs)
        {
            if (ScenarioContextContainsNoBrowserScenarioTag(activatedEventArgs)) 
                return;

            if (activatedEventArgs.Instance is not Webpage.Webpage webpage) 
                return;
            
            var webDriver = activatedEventArgs.Context.Resolve<IWebDriver>();
            webpage.WebDriver = webDriver;
        }

        private static bool ScenarioContextContainsNoBrowserScenarioTag(IActivatedEventArgs<object> activatedEventArgs)
        {
            var scenarioContext = activatedEventArgs.Context.Resolve<ScenarioContext>();
            var scenarioContextTagContainsNoBrowser = scenarioContext.ScenarioInfo.Tags.Contains(Constants.NoBrowserTag);

            return scenarioContextTagContainsNoBrowser;
        }
    }
}