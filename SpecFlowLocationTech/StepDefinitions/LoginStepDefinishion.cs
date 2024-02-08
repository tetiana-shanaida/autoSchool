﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using BoDi;
using OpenQA.Selenium.Interactions;

namespace SpecFlowLocationTech.StepDefinitions
{
    public class LoginStepDefinishion
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Actions action;
        public LoginStepDefinishion(IObjectContainer conteiner)
        {
            driver = conteiner.Resolve<IWebDriver>();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            action = new Actions(driver);
        }

        [Given(@"user is logged in")]
        public void GivenUserIsLoggedIn() {
            driver.Navigate().GoToUrl("http://54.173.239.233/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("maestro+maestro-super-admin-00@locationtech.com");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("Find1tFastN0w+super-admin-00");
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
        }

    }
}
