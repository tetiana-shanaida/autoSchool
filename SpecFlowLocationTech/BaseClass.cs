using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowLocationTech
{
    public class BaseClass
    {
        private IWebDriver webdriver;
        private WebDriverWait wait;
        private Actions action;
        public BaseClass(IObjectContainer conteiner)
        {
            webdriver = conteiner.Resolve<IWebDriver>();
            wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(20));
            action = new Actions(webdriver);
        }


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

        public void NavigateTo(string locator)
        {
            webdriver.Navigate().GoToUrl(locator);
        }

        public void RefreshPage()
        {
            webdriver.Navigate().Refresh();
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

        public void ScrollToElement(string locator)
        {
            wait.Until(e => e.FindElements(By.XPath(locator)));
            ((IJavaScriptExecutor)webdriver).ExecuteScript("arguments[0].scrollIntoView(true);", FindElement(locator));
        }
    }
}
