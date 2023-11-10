using BoDi;
using OpenQA.Selenium;

namespace BDD3.PageObject.Elements
{
    public class Buttons:BaseClass
    {
        private IWebDriver webDriver;
        public Buttons(IObjectContainer conteiner) : base(conteiner)
        {
            webDriver = conteiner.Resolve<IWebDriver>();
        }

        private string DoubleClickMe = "//button[@id='doubleClickBtn']";
        private string RightClickMe = "//button[@id='rightClickBtn']";
        private string ClickMe = "//button[text()='Click Me']";
        private string textAfterClicking = "//div[@class='mt-4']/following-sibling::p[contains(@id, 'ClickMessage')]";


        public Buttons GoToButtonsSection()
        {
            ScrollToElement(SectionByName("Buttons"));
            Click(SectionByName("Buttons"));

            return this;
        }

        public void ClickOnButton(string buttonName) {
            switch (buttonName)
            {
                case "Double Click Me":
                    ScrollToElement(DoubleClickMe);
                    DoubleClick(DoubleClickMe);
                    return;
                case "Right Click Me":
                    RightClick(RightClickMe);
                    return;
                case "Click Me":
                    Click(ClickMe);
                    return;
                default:
                    return;
            }
        }

        public string GetTextAfterClicking()
        {
            return GetElementText(textAfterClicking);
        }
    }
}
