using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Objects.PageObjectModel
{
    public class Asserts:BaseClass
    {
        private IWebDriver webDriver;
        WebDriverWait wait;
        public Asserts(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }
        public void IsElementDispayed(By locator) 
        {
            IWebElement waitAndFindElement = wait.Until(e => e.FindElement(locator));
            Assert.IsTrue(waitAndFindElement.Displayed);
        }
    }
}
