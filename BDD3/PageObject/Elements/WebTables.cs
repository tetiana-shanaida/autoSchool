using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Chrome;
using System.Security.Cryptography.X509Certificates;

namespace BDD3.PageObject.Elements
{
    public class WebTables:BaseClass
    {
        private IWebDriver webDriver;
        public WebTables(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }
        private string ElementCategory => CategoryByName("Elements");
        private string WebTablesSection => SectionByName("Web Tables");

        private string Salary = "//div[text()='Salary']//parent::div[@role=\"columnheader\"]";
        private string SelectorDeleteAlden = "//span[@id='delete-record-2']";

        public WebTables GoToWebTablesSection()
        {
            Click(WebTablesSection);

            return this;
        }

        public WebTables CheckSalaryOrdering()
        {
            Click(Salary); return this;
        }

        public WebTables DeleteAlden()
        {
            Click(SelectorDeleteAlden);
            return this;
        }

        public int CountRows() 
        {
            IList<IWebElement> allElements = webDriver.FindElements(By.XPath("//div[contains(@class, '-even') or contains(@class, '-odd')]"));
            var elementsToCount = allElements.Where(element => !element.GetAttribute("class").Contains("-padRow")).ToList();

            int count = elementsToCount.Count;
            return count;
        }

        public bool IfComplianceDepartmentIsntPresent()
        {
            IList<IWebElement> departmentElements = webDriver.FindElements(By.XPath("//div[contains(@class, 'rt-tr')]/div[6]"));
            bool isComplianceIsntPresent = true;
            foreach (IWebElement element in departmentElements)
            {
                if (element.Text.Contains("Compliance"))
                {
                    isComplianceIsntPresent = false;
                    break;
                }
            }
            return isComplianceIsntPresent;
        }
    }
}
