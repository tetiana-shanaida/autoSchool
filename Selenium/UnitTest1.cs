using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class Tests
    {
        IWebDriver webDriver;

        [SetUp]
        public void SetUp()
        {
            webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            webDriver.Navigate().GoToUrl("https://practice.automationtesting.in/shop/");
        }

        [Test]
        public void Search()
        {
            

            //Actions action = new Actions(webDriver);
            //action.MoveToElement(searchIcon).Perform();

            IWebElement searchText = webDriver.FindElement(By.XPath("//input[@title='Search']"));
            //searchText.Click();
            searchText.SendKeys("html");
            IWebElement searchIcon = webDriver.FindElement(By.XPath("//i[@class='icon-search']"));

        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Close();
        }
    }
}