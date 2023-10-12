using BDD3.PageObject.Alert_Frame_Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace BDD3.StepDefinitions
{
    [Binding]
    public class AlertWindowsStepDefinitions
    {
        private IWebDriver webDriver;
        private string url = "https://demoqa.com/";
        private BrowserWindows browserWindows => new BrowserWindows(webDriver);
        private readonly ScenarioContext _scenarioContext;

        public AlertWindowsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void GivenOpenTheBrowser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }
        [Given(@"user is on main page")]
        public void GivenUserIsOnTheMainPage()
        {
            webDriver.Navigate().GoToUrl(url);
        }

        [When(@"user goes to the Alerts, Frame & Windows category")]
        public void WhenUserGoesToTheAlertsFrameWindowsCategory()
        {
            browserWindows.GoToAlertFrameWindowsCategory();
        }

        [Given(@"user is on Browser Windows page")]
        public void GivenUserIsOnBrowserWindowsPage()
        {
            browserWindows.GoToBrowserWindowsSection();
        }

        [When(@"user opens (.*)")]
        public void WhenUserOpens(string buttonName)
        {
            browserWindows.ClickOnButton(buttonName);
        }

        [When(@"user goes to new tab or window")]
        public void WhenUserGoesToNewTabOrWindow()
        {
            string actualText = browserWindows.ChangeTabOrWindow();
            _scenarioContext["ActualText"] = actualText;
        }

        [Then(@"user see text ""([^""]*)"" on the page")]
        public void ThenUserSeeTextOnThePage(string expectedText)
        {
            var actualText = _scenarioContext["ActualText"] as string;
            Assert.AreEqual(expectedText, actualText);
        }
        
        [AfterScenario]
        public void CleanUp()
        {
            webDriver.Quit();
        }

    }
}
