using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace BDD3.Features.Hooks
{
    [Binding]
    public sealed class WebDriwerHooks
    {
        private readonly IObjectContainer _container; 
        public WebDriwerHooks(IObjectContainer container) 
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            IWebDriver webDriver = new ChromeDriver(options);
            webDriver.Manage().Window.Maximize();         

            _container.RegisterInstanceAs<IWebDriver>(webDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var webDriver = _container.Resolve<IWebDriver>();
            webDriver?.Quit();
        }
    }
}