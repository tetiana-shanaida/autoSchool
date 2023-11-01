using BDD3.PageObject.Elements;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BDD3.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {
        private IWebDriver webDriver;
        private readonly IObjectContainer _container;

        private string url = "https://demoqa.com/";

        public ElementsStepDefinitions(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            webDriver = _container.Resolve<IWebDriver>();
            _scenarioContext = scenarioContext;
        }

        private TextBox textBox => new TextBox(webDriver);
        private CheckBox checkBox => new CheckBox(webDriver);
        private WebTables webTables => new WebTables(webDriver);
        private Buttons buttons => new Buttons(webDriver);

        private readonly ScenarioContext _scenarioContext;

        //public ElementsStepDefinitions(ScenarioContext scenarioContext)
        //{
        //    _scenarioContext = scenarioContext;
        //}


        [Given(@"user is on the main page")]
        public void GivenUserIsOnTheMainPage()
        {
            webDriver.Navigate().GoToUrl(url);
        }

        [When(@"user open the element category")]
        public void WhenUserOpenTheElementCategory()
        {
            textBox.GoToElementSection();
        }

        [When(@"user goes to text box section")]
        public void WhenUserGoesToTextBoxSection()
        {
            textBox.GoToTextBox();
        }

        [When(@"user enters personal data: ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" in TextBox form")]
        public void WhenUserEntersPersonalDataInTextBoxForm(string name, string email, string currentAddress, string permanentAddress)
        {
            textBox.FillInForm(name, email, currentAddress, permanentAddress);

            string[] expectedData = { name, email, currentAddress, permanentAddress };
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

        [When(@"user goes to checkbox section")]
        public void WhenUserGoesToCheckboxSection()
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

        [When(@"user sorts users' data by ""([^""]*)"" column in the table")]
        public void WhenUserSortsUsersDataByColumnInTheTable(string columnName)
        {
            webTables.OrderBy(columnName);
        }

        [Then(@"users' data are sorted in ""([^""]*)"" order by ""([^""]*)"" column")]
        public void ThenUsersDataAreSortedInOrderByColumn(string salary, string ascending)
        {
        }

        [When(@"user deletes user with name ""([^""]*)""")]
        public void WhenUserDeletesUserWithName(string alden)
        {
            webTables.DeleteAlden();
        }

        [Then(@"there are ""([^""]*)"" users left in the table")]
        public void ThenThereAreUsersLeftInTheTable(int amount)
        {
            int actualRows = webTables.CountRows();
            int expectedRows = amount;
            Assert.AreEqual(expectedRows, actualRows, $"{actualRows} isn't equal to {expectedRows}");
        }

        [Then(@"the ""([^""]*)"" value is deleted from the Department column")]
        public void ThenTheValueIsDeletedFromTheDepartmentColumn(string departmentValue)
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
    }
}
