using OpenQA.Selenium;

namespace Page_Objects.PageObjectModel
{
    public class BaseClass
    {
        private IWebDriver webdriver;

        public BaseClass(IWebDriver driver)
        {
            this.webdriver = driver;
        }

        public IWebElement FindElement(By locator)
        {
            return webdriver.FindElement(locator);
        }

        public void Click(By locator)
        {
            FindElement(locator).Click();
        }

        public void FillInputField(By locator, string text)
        {
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public string GetElementAttribute(By locator, string attribute)
        {
            return FindElement(locator).GetAttribute(attribute);
        }
    }
}
