using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace BDD3.PageObject.Widgets
{
    public class AutoComplete:BaseClass
    {
        private IWebDriver webDriver;

        public AutoComplete(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            this.webDriver = new ChromeDriver();
        }

        private string multipleColorNamesInputField = "//input[@id='autoCompleteMultipleInput']";
        private string singleColorNameInputField = "//input[@id='autoCompleteSingleInput']";
    }
}
