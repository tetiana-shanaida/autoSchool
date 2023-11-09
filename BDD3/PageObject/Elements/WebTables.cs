using BoDi;
using OpenQA.Selenium;

namespace BDD3.PageObject.Elements
{
    public class WebTables:BaseClass
    {
        private IWebDriver webDriver;
        public WebTables(IObjectContainer conteiner) : base(conteiner)
        {
            webDriver = conteiner.Resolve<IWebDriver>();
        }
        private string ColumnName(string columnName) => $"//div[text()='{columnName}']//parent::div[@role=\"columnheader\"]";
        private string SelectorDeleteUserByName(string name) => $"//div[text()='{name}']//following-sibling::div//span[@title=\"Delete\"]";

        public WebTables GoToWebTablesSection()
        {
            ScrollToElement(SectionByName("Web Tables"));
            Click(SectionByName("Web Tables"));
            return this;
        }
        public WebTables OrderByColumnName(string columnName)
        {
            Click(ColumnName(columnName)); 
            return this;
        }

        public void CheckSortingByColumnInOrder(string columnName, string order)
        {

        }

        public WebTables DeleteUserByName(string name)
        {
            Click(SelectorDeleteUserByName(name));
            return this;
        }

        public int CountRows() 
        {
            IList<IWebElement> allElements = FindElements("//div[contains(@class, '-even') or contains(@class, '-odd')]");
            var elementsToCount = allElements.Where(element => !element.GetAttribute("class").Contains("-padRow")).ToList();

            int count = elementsToCount.Count;
            return count;
        }

        public bool IfDepartmentValueIsntPresent(string value)
        {
            var departmentElements = FindElements("//div[contains(@class, 'rt-tr')]/div[6]");
            bool isDepartmentValueIsntPresent = true;
            foreach (IWebElement element in departmentElements)
            {
                if (element.Text.Contains(value))
                {
                    isDepartmentValueIsntPresent = false;
                    break;
                }
            }
            return isDepartmentValueIsntPresent;
        }
    }
}
