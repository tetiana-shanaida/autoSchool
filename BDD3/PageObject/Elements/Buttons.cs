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

        public string ClickOnButton(string buttonName) {
            switch (buttonName)
            {
                case "Double Click Me":
                    Click(DoubleClickMe);
                    return "You have done a double click";
                case "Right Click Me":
                    Click(RightClickMe);
                    return "You have done a right click";
                case "Click Me":
                    Click(ClickMe);
                    return "You have done a dynamic click";
                default:
                    return "Invalid button name";
            }
        }

        public string GetTextAfterClicking()
        {
            return GetElementText(textAfterClicking);
        }
    }
}
