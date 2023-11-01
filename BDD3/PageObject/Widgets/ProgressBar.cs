using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDD3.PageObject.Widgets
{
    public class ProgressBar:BaseClass
    {
        private IWebDriver webDriver;

        public ProgressBar(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        private string actionButtonById(string id) => $"//button[@id='{id}']";
        private string buttonName = "//div[@id='progressBarContainer']//child::button";
        private string progressBarInfo = "//div[@class='progress-bar bg-info']";

        public void GoToProgressBarSection()
        {
            Click(SectionByName("Progress Bar"));
        }

        public void StartProgressBar()
        {
            Click(actionButtonById("startStopButton"));
        }

        public void ResetProgress() 
        {
            Click(actionButtonById("resetButton"));
        }

        //public void WaitUntillProgressBarDone()
        //{
        //    WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
        //    wait.Until(e => e.TextToBePresentInElementValue(FindElement("//div[@role='progressbar']"), "100"));

        //}

        public string GetButtonName()
        {
            return GetElementText(buttonName);
        }

        public int GetValueOfProgressBar()
        {
            string progressBarValue = FindElement(progressBarInfo).GetAttribute("aria-valuenow");
            return Int32.Parse(progressBarValue);
        }

    }
}
