using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace BDD3.PageObject.Alert_Frame_Windows
{
    public class BrowserWindows:BaseClass
    {
        private IWebDriver webDriver;

        public BrowserWindows(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        private string ButtonByID(string id) => $"//button[@id='{id}']";
        private string textOnNewPage = "//h1[@id='sampleHeading']";

        public BrowserWindows GoToAlertFrameWindowsCategory()
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", FindElement(CategoryByName("Alerts, Frame & Windows")));
            Click(CategoryByName("Alerts, Frame & Windows"));
            Click("//div[text()='Alerts, Frame & Windows']//following-sibling::div");
            return this;

        }

        public BrowserWindows GoToBrowserWindowsSection()
        {
            Click(SectionByName("Browser Windows"));
            return this;
        }

        public BrowserWindows ClickOnButton(string id)
        {
            Click(ButtonByID(id));
            return this;
        }

        public string ChangeTabOrWindow()
        {
            string originalWindow = webDriver.CurrentWindowHandle;
            var allWindows = webDriver.WindowHandles;

            foreach(var window in allWindows)
            {
                if (originalWindow != window)
                {
                    webDriver.SwitchTo().Window(window);
                    break;
                }
            }
            return GetElementText(textOnNewPage);
        }
    }
}
