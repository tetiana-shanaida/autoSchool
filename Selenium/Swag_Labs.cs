using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

        [OneTimeSetUp]
        public void SetUp()
        {
            webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            webDriver.Close();
        }

        [Test, Order(1)]
        public void LogIn()
        {
            IWebElement user_name = webDriver.FindElement(By.XPath("//input[@id='user-name']"));
            user_name.SendKeys("standard_user");
            IWebElement password = webDriver.FindElement(By.XPath("//input[@id='password']"));
            password.SendKeys("secret_sauce");
            webDriver.FindElement(By.XPath("//input[@id='login-button']")).Click();
            bool isDisplayedHeader = webDriver.FindElement(By.XPath("//div[@class='header_label']")).Displayed;
            Assert.IsTrue(isDisplayedHeader);
        }

        [Test, Order(2)]
        public void PriceIsDisplayed()
        {
            List<double> expectedPrices = new List<double>() {29.99, 9.99, 15.99, 49.99, 7.99, 15.99};
            List<double> actualPrices = new List<double>();
            IReadOnlyList<IWebElement> prices = webDriver.FindElements(By.XPath("//div[@class='inventory_item_price']"));
            foreach (IWebElement price in prices)
            {
                string strPrice = price.Text;
                double dblPrice = double.Parse(strPrice.Substring(1), CultureInfo.InvariantCulture);
                actualPrices.Add(dblPrice);
            }
            Assert.AreEqual(expectedPrices, actualPrices, $"{actualPrices} are not equal to {expectedPrices}");
        }

        [Test, Order(3)]
        public void AddLabsBikeLightToCart()
        {
            webDriver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();
            bool isAddedToCart = webDriver.FindElement(By.XPath("//button[@id = 'remove-sauce-labs-bike-light']")).Displayed;
            Assert.IsTrue(isAddedToCart);
        }

        [Test, Order(4)]
        public void GoToSauceLabsFleeceJacket()
        {
            webDriver.FindElement(By.XPath("//a[@id = 'item_5_title_link']")).Click(); //тут xpath можна було б по назві і взяти батьківський елемент або ось так по id, я подумала що по id зручніше і по назві тесту можна зрозуміти який саме продукт
            bool goneToProduct = webDriver.FindElement(By.XPath("//div[@class='inventory_details_desc_container']/div[text()='Sauce Labs Fleece Jacket']")).Displayed;
            Assert.IsTrue(goneToProduct);
        }

        [Test, Order(5)]
        public void CheckPageTitle() 
        {
            string expectedTitle = "Swag Labs";
            string actualTitle = webDriver.Title;
            Assert.AreEqual(expectedTitle, actualTitle, $"{actualTitle} isn't equal to {expectedTitle}");
        }

        [Test, Order(6)]
        public void AddSauceLabsFleeceJacketToCart()
        {
            webDriver.FindElement(By.XPath("//button[@name='add-to-cart-sauce-labs-fleece-jacket']")).Click();
            bool productIsAdded = webDriver.FindElement(By.XPath("//button[@id='remove-sauce-labs-fleece-jacket']")).Displayed;
            Assert.IsTrue(productIsAdded);
        }

        [Test, Order(7)]
        public void GoToCart()
        {
            webDriver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
            bool goneToCart = webDriver.FindElement(By.XPath("//span[text()='Your Cart']")).Displayed;
            Assert.IsTrue(goneToCart);
        }

        [Test, Order(8)]
        public void GoToCheckout()
        {
            webDriver.FindElement(By.XPath("//button[@id='checkout']")).Click();
            bool goneToCheckout = webDriver.FindElement(By.XPath("//span[contains(text(), 'Checkout')]")).Displayed;
            Assert.IsTrue(goneToCheckout);
        }

        [Test, Order(9)]
        public void FillCheckoutForm()
        {
            webDriver.FindElement(By.XPath("//input[@id='first-name']")).SendKeys("Elia");
            webDriver.FindElement(By.XPath("//input[@id='last-name']")).SendKeys("Solem");
            webDriver.FindElement(By.XPath("//input[@id='postal-code']")).SendKeys("46000");
            webDriver.FindElement(By.XPath("//input[@id='continue']")).Click();
            bool goneToCheckoutOverviewPage = webDriver.FindElement(By.XPath("//span[text()='Checkout: Overview']")).Displayed;
            Assert.IsTrue(goneToCheckoutOverviewPage);
        }

        [Test, Order(10)]
        public void CheckProductsAmound()
        {
            IReadOnlyList<IWebElement> items = webDriver.FindElements(By.XPath("//div[@class='cart_item']"));
            Assert.AreEqual(2, items.Count);
        }

        [Test, Order(11)]
        public void CheckPrice()
        {
            double expectedTotal = 64.78;
            string actualTotalText = webDriver.FindElement(By.XPath("//div[contains(@class, 'summary_total_label')]")).Text;
            string[] arrayOfTextAndPrice = actualTotalText.Split('$');
            double actualTotal = double.Parse(arrayOfTextAndPrice[1], CultureInfo.InvariantCulture);
            Assert.AreEqual(expectedTotal, actualTotal, $"{actualTotal} not equal {expectedTotal}");
        }

    }
}
