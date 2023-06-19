using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Page_Objects.PageObjectModel
{
    public class BaseClass
    {
        private IWebDriver webdriver;
        private WebDriverWait wait;

        public BaseClass(IWebDriver driver)
        {
            this.webdriver = driver;
            wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(10));
        }

        public IWebElement FindElement(string locator)
        {
            var element = wait.Until(e => e.FindElement(By.XPath(locator)));
            return element;
        }

        public BaseClass Click(string locator)
        {
            wait.Until(e => e.FindElement(By.XPath(locator)));
            FindElement(locator).Click();
            return this;
        }

        public BaseClass FillInputField(string locator, string text)
        {
            var element = wait.Until(e => e.FindElement(By.XPath(locator)));
            element.Clear();
            element.SendKeys(text);

            return this;
        }

        public string GetElementAttribute(string locator, string attribute)
        {
            wait.Until(e => e.FindElement(By.XPath(locator)));
            return FindElement(locator).GetAttribute(attribute);
        }

        public string GetElementText(string locator)
        {
            wait.Until(e => e.FindElement(By.XPath(locator)));
            return FindElement(locator).Text;
        }
    }
}
