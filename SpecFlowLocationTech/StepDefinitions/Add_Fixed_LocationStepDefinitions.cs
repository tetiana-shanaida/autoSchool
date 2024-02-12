using BoDi;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowLocationTech.StepDefinitions
{
    [Binding]
    public class Add_Fixed_LocationStepDefinitions:BaseClass
    {
        private IWebDriver webDriver;
        public Add_Fixed_LocationStepDefinitions(IObjectContainer conteiner) : base(conteiner)
        {
            webDriver = conteiner.Resolve<IWebDriver>();
        }

        private string loginPage = "http://54.173.239.233/";
        public string addFixedLocationPage = "http://54.173.239.233/admin/core/fixedlocation/add/";
        private string InputField(string name) => $"//input[@name='{name}']";
        private string loginButton = "//button[@name='login']";
        private string searchInput = "//input[@class='select2-search__field']";
        private string searchResult = "//span[@class='select2-results']//li";
        private string FieldByAria(string value) => $"//span[@aria-labelledby='select2-id_{value}-container']";
     

        [Given(@"user is logged in the admin panel")]
        public void GivenUserIsLoggedInTheAdminPanel()
        {
            NavigateTo(loginPage);
            RefreshPage();
            FillInputField(InputField("username"), "maestro+maestro-super-admin-00@locationtech.com");
            FillInputField(InputField("password"), "Find1tFastN0w+super-admin-00");
            Click(loginButton);
        }

        [When(@"user goes to the page for creating fixed location")]
        public void WhenUserGoesToThePageForCreatingFixedLocation()
        {
            NavigateTo(addFixedLocationPage);
        }

        [When(@"user enters ""([^""]*)"" in the name field in Identity Information")]
        public void WhenUserEntersInTheNameFieldInIdentityInformation(string name)
        {
            FillInputField(InputField("name"), name);
        }

        [When(@"select client name ""([^""]*)""")]
        public void WhenSelectClientName(string clientName)
        {
            Click(FieldByAria("client"));
            FillInputField(searchInput, clientName);
            Thread.Sleep(2000);
            Click(searchResult);
            Thread.Sleep(1000);
        }

        [When(@"select organization name ""([^""]*)""")]
        public void WhenSelectOrganizationName(string orgName)
        {
            Click(FieldByAria("org"));
            FillInputField(searchInput, orgName);
            Thread.Sleep(2000);
            Click(searchResult);
            Thread.Sleep(1000);
        }

        [When(@"select floor ""([^""]*)""")]
        public void WhenSelectFloor(string floorID)
        {
            ScrollToElement(FieldByAria("org"));
            Click(FieldByAria("floor"));
            FillInputField(searchInput, floorID);
            Thread.Sleep(2000);
            Click(searchResult);
            Thread.Sleep(1000);
        }

        [When(@"enter Leaf Location ""([^""]*)""")]
        public void WhenEnterLeafLocation(string leafLocation)
        {
            FillInputField(InputField("leaf_tag"), leafLocation);
        }

        [When(@"save the form")]
        public void WhenSaveTheForm()
        {
            Click(InputField("_save"));
        }
    }
}
