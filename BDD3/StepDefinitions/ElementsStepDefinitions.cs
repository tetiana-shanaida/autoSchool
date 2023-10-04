using BDD3.PageObject.Elements;
using BDD3.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Diagnostics.SymbolStore;

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

        [Given(@"open the browser")]
        public void GivenOpenTheBrowser()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }


        [Given(@"user is on main page")]
        public void GivenUserIsOnMainPage()
        {
            webDriver.Navigate().GoToUrl(url);
        }

        [When(@"user cliks on element category")]
        public void WhenUserCliksOnElementCategory()
        {
            textBox.GoToElementSection();   
        }

        [When(@"user clicks on text box section")]
        public void WhenUserClicksOnTextBoxSection()
        {
            textBox.GoToTextBox();
        }

        [When(@"user enters data")]
        public void WhenUserEntersData()
        {
            textBox.FillInForm("Tania", "tanya@gmail.com", "Ternopil", "Odessa");
        }

        [Then(@"entered data are displayed in appeared table")]
        public void ThenEnteredDataAreDisplayedInAppearedTable()
        {
            textBox.GetActualData();
            Assert.AreEqual(textBox.expectedData, textBox.actualData, $"actual isn't equal to expected");
        }

        [When(@"user clicks on check box section")]
        public void WhenUserClicksOnCheckBoxSection()
        {
            checkBox.GoToCheckBoxSection();
        }

        [When(@"user expand home folder")]
        public void WhenUserExpandHomeFolder()
        {
            checkBox.ExpandHomeFolder();
        }

        [When(@"user select Desktop folder")]
        public void WhenUserSelectDesktopFolder()
        {
            checkBox.SelectDesktop();
        }

        [When(@"user select Angular and Veu from WorkSpace folder")]
        public void WhenUserSelectAngularAndVeuFromWorkSpaceFolder()
        {
            checkBox.SelectAngularAndVeu();
        }

        [When(@"user expandOffice folder and clicks on each element in folder")]
        public void WhenUserExpandOfficeFolderAndClicksOnEachElementInFolder()
        {
            checkBox.ExpandOfficeFolder();
        }

        [When(@"user expand Downloads folder and select it")]
        public void WhenUserExpandDownloadsFolderAndSelectIt()
        {
            checkBox.DownloadFolder();
        }

        [Then(@"user see text You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile")]
        public void ThenUserSeeTextYouHaveSelectedDesktopNotesCommandsAngularVeuOfficePublicPrivateClassifiedGeneralDownloadsWordFileExcelFile()
        {
            checkBox.ActualText();
            Assert.AreEqual(checkBox.expectedText, checkBox.actualText, $"expected isn't equal to actual");
        }


        [Given(@"user is on WebTables page")]
        public void GivenUserIsOnWebTablesPage()
        {
            webTables.GoToWebTablesSection();
        }

        [When(@"user clicks on Salary column")]
        public void WhenUserClicksOnSalaryColumn()
        {
            webTables.CheckSalaryOrdering();
        }

        [Then(@"the values in the Salary column are sorted in ascending order")]
        public void ThenTheValuesInTheSalaryColumnAreSortedInAscendingOrder()
        {
            
        }

        [When(@"user delete second line\(name is Alden\)")]
        public void WhenUserDeleteSecondLineNameIsAlden()
        {
            webTables.DeleteAlden();
        }

        [Then(@"there are only two rows left in the table")]
        public void ThenThereAreOnlyTwoRowsLeftInTheTable()
        {
            int actualRows = webTables.CountRows();
            int expectedRows = 2;
            Assert.AreEqual(expectedRows, actualRows, $"{actualRows} isn't equal to {expectedRows}");
        }

        [Then(@"the values in the Department column do not contain the value Compliance")]
        public void ThenTheValuesInTheDepartmentColumnDoNotContainTheValueCompliance()
        {
            Assert.IsTrue(webTables.IfComplianceDepartmentIsntPresent());
        }



        [AfterScenario]
        public void CleanUp()
        {
            webDriver.Quit();
        }
    }
}
