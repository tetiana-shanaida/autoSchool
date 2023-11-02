using BDD3.PageObject.Interactions;
using BoDi;
using OpenQA.Selenium;
using NUnit.Framework;


namespace BDD3.StepDefinitions
{
    [Binding]
    public class InteractionsStepDefinitions
    {
        private IWebDriver webDriver;
        private readonly IObjectContainer _container;
        public InteractionsStepDefinitions(IObjectContainer container)
        {
            _container = container;
            webDriver = _container.Resolve<IWebDriver>();
        }
        private Selectable selectable => new Selectable(webDriver);

        [When(@"user open the Interactions category")]
        public void WhenUserOpenTheInteractionsCategory()
        {
            selectable.GoToInteractionsCategory();
        }

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
        public void WhenUserSelectsSquare(string squareNumber)
        {
            selectable.SelectItem(squareNumber);
        }

        [Then(@"the values in selected squares are: ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)""")]
        public void ThenTheValuesInSelectedSquaresAre(string one, string three, string five, string seven, string nine)
        {
            List<string> expactedValues = new List<string> {one, three, five, seven, nine};
            List<string> actualValues = selectable.GetSelectedItems();
            Assert.AreEqual(expactedValues, actualValues);
        }


    }
}
