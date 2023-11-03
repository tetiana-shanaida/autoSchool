using OpenQA.Selenium;

namespace BDD3.PageObject.Elements
{
    public class Buttons:BaseClass
    {
        private IWebDriver webDriver;
        public Buttons(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        private string ButtonsSection => SectionByName("Buttons");
        private string DoubleClickMe = "//button[@id='doubleClickBtn']";
        private string RightClickMe = "//button[@id='rightClickBtn']";
        private string ClickMe = "//button[text()='Click Me']";


        public Buttons GoToButtonsSection()
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", FindElement(ButtonsSection));
            Click(ButtonsSection);

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
    }
}
