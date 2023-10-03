using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace BDD3.PageObject.Widgets
{
    public class ProgressBar:BaseClass
    {
        private IWebDriver webDriver;

        public ProgressBar(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            this.webDriver = new ChromeDriver();
        }

        private string startButton = "//button[@id='startStopButton']";
    }
}
