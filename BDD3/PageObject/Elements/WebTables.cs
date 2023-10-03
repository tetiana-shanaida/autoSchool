using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDD3.PageObject.Elements
{
    public class WebTables:BaseClass
    {
        private IWebDriver webDriver;
        public WebTables(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            this.webDriver = new ChromeDriver();
        }
        private string ElementCategory => CategoryByName("Elements");
        private string WebTablesSection => SectionByName("Web Tables");

        private string Salary = "//div[text()='Salary']//parent::div[@role=\"columnheader\"]";
        private string DeleteAlden = "//span[@id='delete-record-2']";

        public WebTables GoToWebTablesSection()
        {
            Click(ElementCategory);
            Click(WebTablesSection); //maybe I should open list before it

            return this;
        }
    }
}
