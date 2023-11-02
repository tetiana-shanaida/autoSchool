using OpenQA.Selenium;

namespace BDD3.Features.Hooks
{
    [Binding]
    public sealed class NavigateToMainPage
    {
        private IWebDriver webDriver;
        private string homePage = "https://demoqa.com/";
        public NavigateToMainPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            webDriver.Navigate().GoToUrl(homePage);
        }
    }
}