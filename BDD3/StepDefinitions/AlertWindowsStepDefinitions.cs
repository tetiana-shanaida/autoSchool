using BDD3.PageObject.Alert_Frame_Windows;
using NUnit.Framework;
using BoDi;

namespace BDD3.StepDefinitions
{
    [Binding]
    public class AlertWindowsStepDefinitions
    {
        private readonly IObjectContainer _container;

        public AlertWindowsStepDefinitions(IObjectContainer container, BrowserWindows browserWindows)
        {
            _container = container;
            this.browserWindows = browserWindows;
        }
        private BrowserWindows browserWindows;

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
            browserWindows.ChangeTabOrWindow();
        }

        [Then(@"user see text ""([^""]*)"" on the page")]
        public void ThenUserSeeTextOnThePage(string expectedText)
        {
            var actualText = browserWindows.GetTextOnNewPage();
            Assert.AreEqual(expectedText, actualText);
        }
    }
}
