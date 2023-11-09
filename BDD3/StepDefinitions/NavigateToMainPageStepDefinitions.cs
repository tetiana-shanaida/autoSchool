using OpenQA.Selenium;

namespace BDD3.StepDefinitions
{
    [Binding]
    public class NavigateToMainPageStepDefinitions
    {
        private IWebDriver webDriver;
        private string homePage = "https://demoqa.com/";
        public NavigateToMainPageStepDefinitions(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        [Given(@"user is on the main page")]
        public void GivenUserIsOnTheMainPage()
        {
            webDriver.Navigate().GoToUrl(homePage);
        }
    }
}
