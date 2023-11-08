﻿using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD3.PageObject
{
    public class BaseClass
    {
        private IWebDriver webdriver;
        private WebDriverWait wait;

        public BaseClass(IObjectContainer conteiner)
        {
            webdriver = conteiner.Resolve<IWebDriver>();
            wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(10));
        }

        protected string CategoryByName (string name) => $"//h5[text()='{name}']//parent::div[@class='card-body']";
        protected string SectionByName(string name) => $"//span[text()='{name}']//ancestor::li";

        public IWebElement FindElement(string locator)
        {
            var element = wait.Until(e => e.FindElement(By.XPath(locator)));
            return element;
        }

        public IList<IWebElement> FindElements(string locator)
        {
            var elements = wait.Until(e => e.FindElements(By.XPath(locator)));
            return elements;
        }

        public void Click(string locator)
        {
            FindElement(locator).Click();
        }

        public void FillInputField(string locator, string text)
        {
            var element = FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public string GetElementAttribute(string locator, string attribute)
        {
            return FindElement(locator).GetAttribute(attribute);
        }

        public void ScrollToElement(string locator)
        {
            ((IJavaScriptExecutor)webdriver).ExecuteScript("arguments[0].scrollIntoView(true);", FindElement(SectionByName(locator)));
        }
        public string GetElementText(string locator)
        {
            return FindElement(locator).Text;
        }
    }
}
