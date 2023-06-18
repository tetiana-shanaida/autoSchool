using Page_Objects.PageObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Page_Objects.Tests
{
    public class LoginTests
    {
        IWebDriver webDriver;
        LoginForm loginForm;
        RegisterForm registerForm;
        WebDriverWait wait;
        Asserts asserts;

        [SetUp]
        public void SetUp()
        {
            webDriver = new ChromeDriver();
            loginForm = new LoginForm(webDriver);
            registerForm = new RegisterForm(webDriver);
            asserts = new Asserts(webDriver);
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://practice.automationtesting.in/my-account/");
        }

        [TearDown]
        public void TearDown()
        {
            webDriver?.Quit();
        }

        [Test]
        public void Login()
        {
            string username = "user2563";
            string password = "0y4F8S^D7W4c";
            loginForm.Login(username, password);

            string accountDetailsButton = "//a[text()='Account Details']";
            wait.Until(e => e.FindElement(By.XPath(accountDetailsButton)));
            asserts.IsElementDispayed(By.XPath(accountDetailsButton));
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
