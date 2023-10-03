using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace BDD3.PageObject.Interactions
{
    public class Selectable:BaseClass
    {
        private IWebDriver webDriver;

        public Selectable(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            this.webDriver = new ChromeDriver();
        }

        private string GroupItemByText (string text) => $"//li[text()={text}]";

        private string gridTab = "//a[@id='demo-tab-grid']";
        private string OneItem => GroupItemByText("One");
        private string ThreeItem => GroupItemByText("Three");
        private string FiveItem => GroupItemByText("Five");
        private string SevenItem => GroupItemByText("Seven");
        private string NineItem => GroupItemByText("Nine");
    }
}
