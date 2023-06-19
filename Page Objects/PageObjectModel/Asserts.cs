using NUnit.Framework;
using OpenQA.Selenium;

namespace Page_Objects.PageObjectModel
{
    public class Asserts:BaseClass
    {
        private IWebDriver webDriver;

        public Asserts(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        public Asserts IsElementDispayed(string locator) 
        {
            IWebElement element = FindElement(locator);
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
