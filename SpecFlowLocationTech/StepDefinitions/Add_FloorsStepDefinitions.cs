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
    public class Add_FloorsStepDefinitions
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private Actions action;
        public Add_FloorsStepDefinitions(IObjectContainer conteiner)
        {
            driver = conteiner.Resolve<IWebDriver>();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            action = new Actions(driver);
        }

        private string building_field = "//span[@aria-labelledby=\"select2-id_building-container\"]";
        private string build_input = "//input[@aria-controls='select2-id_building-results']";
        private string selected_build = "//li[@class=\"select2-results__option select2-results__option--highlighted\"]";
        private string floorName = "//input[@id=\"id_name\"]";
        private string floorNumber= "//input[@id=\"id_floor_number\"]";
        private string save_button = "//input[@value='Save']";

        [Given(@"user is logged in main page")]
        public void GivenUserIsLoggedInMainPage()
        {
            driver.Navigate().GoToUrl("http://54.173.239.233/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Navigate().Refresh();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("maestro+maestro-super-admin-00@locationtech.com");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("Find1tFastN0w+super-admin-00");
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
        }

        [When(@"user select ""([^""]*)"" bulding")]
        public void WhenUserSelectBulding(string id)
        {
            driver.Navigate().GoToUrl("http://54.173.239.233/admin/core/floor/add/");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(building_field)));

            driver.FindElement(By.XPath(building_field)).Click();
            driver.FindElement(By.XPath(build_input)).SendKeys(id);
            Thread.Sleep(6000);
            driver.FindElement(By.XPath(selected_build)).Click();
            Thread.Sleep(1000);
        }

        [When(@"enter floor name (.*)")]
        public void WhenEnterFloorName(int floor_name)
        {
            string floorname = floor_name.ToString();
            driver.FindElement(By.XPath(floorName)).SendKeys(floorname);
        }

        [When(@"enter floor number (.*)")]
        public void WhenEnterFloorNumber(int floor_numb)
        {
            string floornumb = floor_numb.ToString();
            driver.FindElement(By.XPath(floorNumber)).SendKeys(floornumb);
        }

        [When(@"user save floor")]
        public void WhenUserSaveFloor()
        {
            driver.FindElement(By.XPath(save_button)).Click();
        }
    }
}
