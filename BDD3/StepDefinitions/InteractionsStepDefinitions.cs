using BDD3.PageObject.Alert_Frame_Windows;
using BDD3.PageObject.Interactions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace BDD3.StepDefinitions
{
    [Binding]
    public class InteractionsStepDefinitions
    {
        private IWebDriver webDriver;
        private Selectable selectable => new Selectable(webDriver);


        [Given(@"user is on Selectable page")]
        public void GivenUserIsOnSelectablePage()
        {
            selectable.GoToSelectableSection();
        }

        [When(@"user goes to ""([^""]*)"" tab")]
        public void WhenUserGoesToTab(string grid)
        {
            selectable.OpenTab(grid);
        }

        [When(@"user selects square ""([^""]*)""")]
        public void WhenUserSelectsSquare(string number)
        {
            selectable.SelectItem(number);
        }

        [Then(@"")]
        public void Then()
        {
            throw new PendingStepException();
        }
    }
}
