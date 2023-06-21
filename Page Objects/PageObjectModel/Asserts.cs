using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Page_Objects.PageObjectModel
{
    public class Asserts:BaseClass
    {
        private IWebDriver webDriver;
        private WebDriverWait wait;

        public Asserts(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }

        public Asserts IsElementDispayed(string locator) 
        {
            IWebElement element = wait.Until(e => e.FindElement(By.XPath(locator)));
            Assert.IsTrue(element.Displayed);
            return this;
        }

        public Asserts AreEqual(string expected, string actual)
        {
            Assert.AreEqual(expected, actual, $"{actual} isn't equal to {expected}");
            return this;
        }
    }
}
