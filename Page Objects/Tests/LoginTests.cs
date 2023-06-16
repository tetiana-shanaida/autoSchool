﻿using Page_Objects.PageObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V112.Overlay;

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
            loginForm.Login(username, "0y4F8S^D7W4c");

            asserts.IsElementDispayed(By.XPath("//a[text()='Account Details']"));
        }

        [Test]
        public void CheckTextFromLostPassword()
        {
            string expectedText = "Lost your password?";
            string actualText = loginForm.GetTextFromLostPassword();
            Assert.AreEqual(expectedText, actualText, $"{actualText} isn't equal to {expectedText}");
        }

        [Test]
        public void CheckTextFromRememberMe()
        {
            string expectedText = "Remember me";
            string actualText = loginForm.GetTextFromRememberMe();
            Assert.AreEqual(expectedText, actualText, $"{actualText} isn't equal to {expectedText}");
        }

        [Test]
        public void CheckTextFromRegisterButton()
        {
            string expectedText = "Register";
            string actualText = registerForm.GetTextFromRegisterButton();
            Assert.AreEqual(expectedText, actualText, $"{actualText} isn't equal to {expectedText}");
        }
    }
}
