using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDD3.PageObject.Elements
{
    public class Buttons:BaseClass
    {
        private IWebDriver webDriver;
        public Buttons(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            this.webDriver = new ChromeDriver();
        }

        private string ElementCategory => CategoryByName("Elements");
        private string ButtonsSection => SectionByName("Buttons");

        public Buttons GoToButtonsSection()
        {
            Click(ElementCategory);
            Click(ButtonsSection); //maybe I should open list before it

            return this;
        }
    }
}
