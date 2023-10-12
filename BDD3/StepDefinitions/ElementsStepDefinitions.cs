using BDD3.PageObject.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;

namespace BDD3.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {
        private IWebDriver webDriver;
        private string url = "https://demoqa.com/";

        private TextBox textBox => new TextBox(webDriver);
        private CheckBox checkBox => new CheckBox(webDriver);
        private WebTables webTables => new WebTables(webDriver);
        private Buttons buttons => new Buttons(webDriver);

        private readonly ScenarioContext _scenarioContext;

        public ElementsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"open the browser")]
        public void GivenOpenTheBrowser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }

        [Given(@"user is on the main page")]
        public void GivenUserIsOnTheMainPage()
        {
            webDriver.Navigate().GoToUrl(url);
        }

        [When(@"user opens the element category")]
        public void WhenUserOpensTheElementCategory()
        {
            textBox.GoToElementSection();
        }

        [When(@"user goes to text box section")]
        public void WhenUserGoesToTextBoxSection()
        {
            textBox.GoToTextBox();
        }

        [When(@"user enters personal data: ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" in form")]
        public void WhenUserEntersPersonalDataInForm(string name, string email, string currentAddress, string permanentAddress)
        {
            textBox.FillInForm(name, email, currentAddress, permanentAddress);

            string[] expectedData = { name, email, currentAddress, permanentAddress};
            _scenarioContext["ExpectedData"] = expectedData;

        }

        [When(@"user submits form")]
        public void WhenUserSubmitsForm()
        {
            textBox.Submit();
        }

        [Then(@"entered data are displayed in the appeared table")]
        public void ThenEnteredDataAreDisplayedInTheAppearedTable()
        {
            List<string> actualData = textBox.GetActualData();
            var expectedData = _scenarioContext["ExpectedData"] as List<string>;
            Assert.AreEqual(expectedData, actualData, $"actual isn't equal to expected");
        }


        [When(@"user goes to check box section")]
        public void WhenUserGoesToCheckBoxSection()
        {
            checkBox.GoToCheckBoxSection();
        }

        [When(@"user expands ""([^""]*)"" folder")]
        public void WhenUserExpandsFolder(string folderName)
        { 
            checkBox.ExpandFolder(folderName);
        }

        [When(@"user selects ""([^""]*)"" folder")]
        public void WhenUserSelectsFolder(string folderName)
        {
            checkBox.SelectFolderOrItem(folderName);
        }

        [Then(@"user see text: ""([^""]*)""")]
        public void ThenUserSeeText(string expectedText)
        {
            string actualText = checkBox.ActualText();
            Assert.AreEqual(expectedText, actualText, $"expected isn't equal to actual");
        }


        [Given(@"user is on the WebTables page")]
        public void GivenUserIsOnTheWebTablesPage()
        {
            webTables.GoToWebTablesSection();
        }

        [When(@"user clicks on ""([^""]*)"" column")]
        public void WhenUserClicksOnColumn(string columnName)
        {
            webTables.OrderBy(columnName);
        }

        [Then(@"the values in the ""([^""]*)"" column are sorted in ""([^""]*)"" order")]
        public void ThenTheValuesInTheColumnAreSortedInOrder(string salary, string ascending)
        {

        }

        [When(@"user deletes ""([^""]*)"" line")]
        public void WhenUserDeletesLine(string alden)
        {
            webTables.DeleteAlden();
        }

        [Then(@"there are only ""([^""]*)"" rows left in the table")]
        public void ThenThereAreOnlyRowsLeftInTheTable(int amount)
        {
            int actualRows = webTables.CountRows();
            int expectedRows = amount;
            Assert.AreEqual(expectedRows, actualRows, $"{actualRows} isn't equal to {expectedRows}");
        }

        [Then(@"the values in the Department column do not contain the value ""([^""]*)""")]
        public void ThenTheValuesInTheDepartmentColumnDoNotContainTheValue(string departmentValue)
        {
            Assert.IsTrue(webTables.IfDepartmentValueIsntPresent(departmentValue));
        }

        [Given(@"user is on Buttons page")]
        public void GivenUserIsOnButtonsPage()
        {
            buttons.GoToButtonsSection();
        }

        [When(@"user clicks on button ""([^""]*)""")]
        public void WhenUserClicksOnButton(string buttonName)
        {
            string expectedMessage = buttons.ClickOnButton(buttonName);
            _scenarioContext["ExpectedMessage"] = expectedMessage;
        }

        [Then(@"the appropriate message is displayed")]
        public void ThenTheAppropriateMessageIsDisplayed()
        {
            var expectedMessage = _scenarioContext["ExpectedMessage"] as string;

        }


        [AfterScenario]
        public void CleanUp()
        {
            webDriver.Quit();
        }
    }
}
