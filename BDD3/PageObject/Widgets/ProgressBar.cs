using BoDi;
using OpenQA.Selenium;

namespace BDD3.PageObject.Widgets
{
    public class ProgressBar:BaseClass
    {
        private IWebDriver webDriver;
        public ProgressBar(IObjectContainer conteiner) : base(conteiner)
        {
            webDriver = conteiner.Resolve<IWebDriver>();
        }

        private string actionButtonById(string id) => $"//button[@id='{id}']";
        private string buttonName = "//div[@id='progressBarContainer']//child::button";
        private string progressBar = "//div[@role='progressbar']";

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

        public void WaitUntillProgressBarDone()
        {
            while(GetElementAttribute(progressBar, "aria-valuenow") != "100")
            {
                Thread.Sleep(1000);
            }
        }

        public string GetButtonName()
        {
            return GetElementText(buttonName);
        }

        public int GetValueOfProgressBar()
        {
            string progressBarValue = GetElementAttribute(progressBar, "aria-valuenow");
            return Int32.Parse(progressBarValue);
        }

    }
}
