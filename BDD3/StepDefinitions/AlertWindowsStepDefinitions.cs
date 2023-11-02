using BDD3.PageObject.Alert_Frame_Windows;
using OpenQA.Selenium;
using NUnit.Framework;
using BoDi;

namespace BDD3.StepDefinitions
{
    [Binding]
    public class AlertWindowsStepDefinitions
    {
        private IWebDriver webDriver;
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _container;

        public AlertWindowsStepDefinitions(ScenarioContext scenarioContext, IObjectContainer container)
        {
            _scenarioContext = scenarioContext;
            _container = container;
            webDriver = _container.Resolve<IWebDriver>();
        }
        private BrowserWindows browserWindows => new BrowserWindows(webDriver);

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
    }
}
