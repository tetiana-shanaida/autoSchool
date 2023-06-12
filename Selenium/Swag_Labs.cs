using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using SeleniumExtras.WaitHelpers;

namespace Selenium
{
    public class Swag_Labs
    {
        IWebDriver webDriver;
        WebDriverWait wait;

        [OneTimeSetUp]
        public void SetUp()
        {
            webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            webDriver.Quit();
        }

        [Test, Order(1)]
        public void LogIn()
        {
            var UserNameInputField = webDriver.FindElement(By.XPath("//input[@id='user-name']"));
            UserNameInputField.Clear();
            UserNameInputField.SendKeys("standard_user");
            var PasswordInputField = webDriver.FindElement(By.XPath("//input[@id='password']"));
            PasswordInputField.Clear();
            PasswordInputField.SendKeys("secret_sauce");
            webDriver.FindElement(By.XPath("//input[@id='login-button']")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='header_label']")));
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
                double ConvertedPrice = double.Parse(price.Text.Substring(1), CultureInfo.InvariantCulture);
                actualPrices.Add(ConvertedPrice);
            }
            Assert.AreEqual(expectedPrices, actualPrices, $"{actualPrices} are not equal to {expectedPrices}");
        }

        [Test, Order(3)]
        public void AddLabsBikeLightToCart()
        {
            webDriver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id = 'remove-sauce-labs-bike-light']")));
            bool isAddedToCart = webDriver.FindElement(By.XPath("//button[@id = 'remove-sauce-labs-bike-light']")).Displayed;
            Assert.IsTrue(isAddedToCart);
        }

        [Test, Order(4)]
        public void GoToSauceLabsFleeceJacket()
        {
            webDriver.FindElement(By.XPath("//div[text()='Sauce Labs Fleece Jacket']/parent::a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='inventory_details_desc_container']/div[text()='Sauce Labs Fleece Jacket']")));
            bool isNavigatedToProductPage = webDriver.FindElement(By.XPath("//div[@class='inventory_details_desc_container']/div[text()='Sauce Labs Fleece Jacket']")).Displayed;
            Assert.IsTrue(isNavigatedToProductPage);
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
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id = 'remove-sauce-labs-bike-light']")));
            bool productIsAdded = webDriver.FindElement(By.XPath("//button[@id='remove-sauce-labs-fleece-jacket']")).Displayed;
            Assert.IsTrue(productIsAdded);
        }

        [Test, Order(7)]
        public void GoToCart()
        {
            webDriver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Your Cart']")));
            bool isNavigatedToCart = webDriver.FindElement(By.XPath("//span[text()='Your Cart']")).Displayed;
            Assert.IsTrue(isNavigatedToCart);
        }

        [Test, Order(8)]
        public void GoToCheckout()
        {
            webDriver.FindElement(By.XPath("//button[@id='checkout']")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[contains(text(), 'Checkout')]")));
            bool isNavigatedToCheckout = webDriver.FindElement(By.XPath("//span[contains(text(), 'Checkout')]")).Displayed;
            Assert.IsTrue(isNavigatedToCheckout);
        }

        [Test, Order(9)]
        public void FillCheckoutForm()
        {
            string InputFieldCheckoutForm(string fieldName) => $"//div[@class='form_group']/input[@name='{fieldName}']";

            var FirstNameInputField = webDriver.FindElement(By.XPath(InputFieldCheckoutForm("firstName")));
            FirstNameInputField.Clear();
            FirstNameInputField.SendKeys("Elia");

            var LastNameInputField = webDriver.FindElement(By.XPath(InputFieldCheckoutForm("lastName")));
            LastNameInputField.Clear();
            LastNameInputField.SendKeys("Solem");

            var PostalCodeInputField = webDriver.FindElement(By.XPath(InputFieldCheckoutForm("postalCode")));
            PostalCodeInputField.Clear();
            PostalCodeInputField.SendKeys("46000");
            webDriver.FindElement(By.XPath("//input[@id='continue']")).Click();

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Checkout: Overview']")));
            bool isNavigatedToCheckoutOverviewPage = webDriver.FindElement(By.XPath("//span[text()='Checkout: Overview']")).Displayed;
            Assert.IsTrue(isNavigatedToCheckoutOverviewPage);
        }

        [Test, Order(10)]
        public void CheckProductsAmound()
        {
            int expectedProductsQuantity = 2;
            IReadOnlyList<IWebElement> actualProductsQuantity = webDriver.FindElements(By.XPath("//div[@class='cart_item']"));
            Assert.AreEqual(expectedProductsQuantity, actualProductsQuantity.Count, $"{actualProductsQuantity} is not equal to {expectedProductsQuantity}");
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
