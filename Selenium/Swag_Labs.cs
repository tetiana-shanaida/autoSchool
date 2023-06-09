using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Selenium
{
    public class Swag_Labs
    {
        IWebDriver webDriver;
        IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        //[OneTimeTearDown]
        //public void TearDown()
        //{
        //    webDriver.Close();
        //}

        [Test]
        public void LogIn()
        {
            IWebElement user_name = webDriver.FindElement(By.XPath("//input[@id='user-name']"));
            user_name.Click();
            user_name.SendKeys("standard_user");
            IWebElement password = webDriver.FindElement(By.XPath("//input[@id='password']"));
            password.Click();
            password.SendKeys("secret_sauce");
            webDriver.FindElement(By.XPath("//input[@id='login-button']")).Click();
        }

        [Test]
        public void PriceIsDisplayed()
        {
            LogIn();
            IReadOnlyList<IWebElement> prices = webDriver.FindElements(By.XPath("//div[@class='inventory_item_price']"));
            foreach (IWebElement price in prices)
            {
                bool isDisplayedPrice = price.Displayed;
            }
        }

        [Test]
        public void AddLabsBikeLightToCart()
        {
            LogIn();
            IWebElement addToCart = webDriver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
            addToCart.Click();
        }

        [Test]
        public void GoToItem()
        {
            IWebElement item = webDriver.FindElement(By.XPath("//a[@id = 'item_5_title_link']"));
            item.Click();
        }

        [Test]
        public void CheckPageTitle() 
        {
            GoToItem();
            js = (IJavaScriptExecutor)webDriver;
            string expectedTitle = "Swag Labs";
            string title = (string)js.ExecuteScript("return document.title");
            Assert.AreEqual(expectedTitle, title, "The title must be equal to expected");
        }

        [Test]
        public void Checkout()
        {
            AddLabsBikeLightToCart();
            GoToItem();
            webDriver.FindElement(By.XPath("//button[@name='add-to-cart-sauce-labs-fleece-jacket']")).Click();
            webDriver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
            webDriver.FindElement(By.XPath("//button[@id='checkout']")).Click();

            webDriver.FindElement(By.XPath("//input[@id='first-name']")).SendKeys("Elia");
            webDriver.FindElement(By.XPath("//input[@id='last-name']")).SendKeys("Solem");
            webDriver.FindElement(By.XPath("//input[@id='postal-code']")).SendKeys("46000");
            webDriver.FindElement(By.XPath("//input[@id='continue']")).Click();

            IReadOnlyList<IWebElement> items = webDriver.FindElements(By.XPath("//div[@class='cart_item']"));
            Assert.AreEqual(2, items.Count);
            
            string expectedTotal = "64.78";
            string actualTotalText = webDriver.FindElement(By.XPath("//div[contains(@class, 'summary_total_label')]")).Text;
            string[] arrayOfTextAndPrice = actualTotalText.Split('$');
            string actualTotal = arrayOfTextAndPrice[1];
            Assert.AreEqual(expectedTotal, actualTotal, $"{expectedTotal} not equal {actualTotal}");
        }

    }
}
