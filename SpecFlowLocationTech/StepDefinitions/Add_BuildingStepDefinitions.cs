using BoDi;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowLocationTech.StepDefinitions
{
    [Binding]
    public class Add_BuildingStepDefinitions
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Actions action;
        public Add_BuildingStepDefinitions(IObjectContainer conteiner)
        {
            driver = conteiner.Resolve<IWebDriver>();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            action = new Actions(driver);
        }

        private string org_field = "//span[@aria-labelledby=\"select2-id_org-container\"]";
        private string org_input = "//input[@aria-controls=\"select2-id_org-results\"]";
        private string selected_org = "//li[text()='NIX Software Development Services']";
        private string building_input = "//input[@id=\"id_name\"]";
        private string save_button = "//input[@value=\"Save\"]";

        [Given(@"user is logged in")]
        public void GivenUserIsLoggedIn()
        {
            driver.Navigate().GoToUrl("http://54.173.239.233/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Navigate().Refresh();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("maestro+maestro-super-admin-00@locationtech.com");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("Find1tFastN0w+super-admin-00");
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
        }


        [When(@"user go to add building page")]
        public void WhenUserGoToAddBuildingPage()
        {
            driver.Navigate().GoToUrl("http://54.173.239.233/admin/core/building/add/");
        }

        [When(@"adds new ""([^""]*)"" building to ""([^""]*)"" organization")]
        public void WhenAddsNewBuildingToOrganization(string office, string nix)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(org_field)));

            driver.FindElement(By.XPath(org_field)).Click();
            //driver.FindElement(By.XPath(org_input)).SendKeys(nix);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(selected_org)).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath(building_input)).SendKeys(office);
            driver.FindElement(By.XPath(save_button)).Click();
        }
    }
}
