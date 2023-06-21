using Page_Objects.PageObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Page_Objects.Tests
{
    public class LoginTests
    {
        private IWebDriver webDriver;
        private LoginForm loginForm;
        private RegisterForm registerForm;
        private Asserts asserts;
        DriverFactory factory;
        private string url = "https://practice.automationtesting.in/my-account/";

        [SetUp]
        public void SetUp()
        {
            factory = new DriverFactory();
            factory.InitializeDriver("Chrome");
            webDriver = factory.webDriver;
            factory.NavigateTo(url);
            loginForm = new LoginForm(webDriver);
            registerForm = new RegisterForm(webDriver);
            asserts = new Asserts(webDriver);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            factory.CloseDriver();
        }

        [Test]
        public void Login()
        {
            string username = "user2563";
            string password = "0y4F8S^D7W4c";
            loginForm.Login(username, password);

            string accountDetailsButton = "//a[text()='Account Details']";
            asserts.IsElementDispayed(accountDetailsButton);
        }

        [Test]
        public void CheckTextFromLostPassword()
        {
            string expectedText = "Lost your password?";
            string actualText = loginForm.GetTextFromLostPassword();
            asserts.AreEqual(expectedText, actualText);
        }

        [Test]
        public void CheckTextFromRememberMe()
        {
            string expectedText = "Remember me";
            string actualText = loginForm.GetTextFromRememberMe();
            asserts.AreEqual(expectedText, actualText);
        }

        [Test]
        public void CheckTextFromRegisterButton()
        {
            string expectedText = "Register";
            string actualText = registerForm.GetTextFromRegisterButton();
            asserts.AreEqual(expectedText, actualText);
        }
    }
}
