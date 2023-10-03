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
            this.webDriver = new ChromeDriver();
        }

        private string newTabButton = "//button[@id='tabButton']";
        public string newWindowButton = "//button[@id='windowButton']";
    }
}
