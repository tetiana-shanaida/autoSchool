using BDD3.PageObject.Widgets;
using OpenQA.Selenium;
using NUnit.Framework;
using BoDi;

namespace BDD3.StepDefinitions
{
    [Binding]
    public class WidgetsStepDefinitions
    {
        private IWebDriver webDriver;
        private string url = "https://demoqa.com/";
        private readonly IObjectContainer _container;

        public WidgetsStepDefinitions(IObjectContainer container)
        {
            _container = container;
            webDriver = _container.Resolve<IWebDriver>();
        }

        private AutoComplete autoComplete => new AutoComplete(webDriver);
        private ProgressBar progressBar => new ProgressBar(webDriver);

        [When(@"user goes to the Widgets category")]
        public void WhenUserGoesToTheWidgetsCategory()
        {
            autoComplete.GoToWidgetsCategory();
        }

        [Given(@"user is on auto-complete page")]
        public void GivenUserIsOnAuto_CompletePage()
        {
            autoComplete.GoToAutoCompleteSection();
        }

        [When(@"user types ""([^""]*)"" in the Type multiple color names field")]
        public void WhenUserTypesInTheTypeMultipleColorNamesField(string text)
        {
            autoComplete.EnterLetter(text);
        }

        [Then(@"autocomplete suggests ""([^""]*)"" variants")]
        public void ThenAutocompleteSuggestsVariants(string expectedAmount)
        {
            int actualAmount = autoComplete.GetAmountOfSuggestedOptions();
            Assert.AreEqual(expectedAmount, actualAmount, $"{expectedAmount} isn't equal to {actualAmount}");
        }

        [Then(@"""([^""]*)"" exists in each variants")]
        public void ThenExistsInEachVariants(string text)
        {
            bool isContainsText = autoComplete.CheckSuggestedOptions(text);
            Assert.IsTrue(isContainsText);
        }

        [When(@"user enters color ""([^""]*)"" in the Type multiple color names field")]
        public void WhenUserEntersColorInTheTypeMultipleColorNamesField(string color)
        {
            autoComplete.EnterColors(color);
        }


        [When(@"user deletes color ""([^""]*)""")]
        public void WhenUserDeletesColor(string color)
        {
            autoComplete.DeleteColor(color);
        }


        [Then(@"""([^""]*)"" color remained in the field")]
        public void ThenColorRemainedInTheField(string color)
        {
            autoComplete.IsColorExistInField(color);
        }


        [Given(@"user is on Progress Bar page")]
        public void GivenUserIsOnProgressBarPage()
        {
            progressBar.GoToProgressBarSection();
        }

        [When(@"user clicks on Start button to start progress bar")]
        public void WhenUserClicksOnStartButtonToStartProgressBar()
        {
            progressBar.StartProgressBar();
        }

        [When(@"user waits until progress bar reaches ""([^""]*)""%")]
        public void WhenUserWaitsUntilProgressBarReaches(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"name of the button is changed to ""([^""]*)""")]
        public void ThenNameOfTheButtonIsChangedTo(string expectedButtonName)
        {
            string actualButtonName = progressBar.GetButtonName();
            Assert.AreEqual(expectedButtonName, actualButtonName, $"{expectedButtonName} isn't equal to {actualButtonName}" );
        }

        [When(@"user clicks on Reset button")]
        public void WhenUserClicksOnResetButton()
        {
            progressBar.ResetProgress();
        }

        [Then(@"value in the progress bar is (.*)%")]
        public void ThenValueInTheProgressBarIs(int expectedPercent)
        {
            int actualPercent = progressBar.GetValueOfProgressBar();
            Assert.AreEqual(expectedPercent, actualPercent, $"{expectedPercent} isn't equal to {actualPercent}");
        }

    }
}
