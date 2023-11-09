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
        private string locatorToSalaryColumn = "//div[@class='rt-tbody']//div[@role='row' and not(contains(@class,'-padRow'))]//div[contains(@class, 'rt-td')][5]";

        public void GoToWebTablesSection()
        {
            ScrollToElement(SectionByName("Web Tables"));
            Click(SectionByName("Web Tables"));
        }
        public WebTables OrderByColumnName(string columnName)
        {
            Click(ColumnName(columnName)); 
            return this;
        }

        public bool CheckSortingByColumnInOrder()
        {
            List<int> salaries = new List<int>();
            var salaryColumns = FindElements(locatorToSalaryColumn);

            foreach ( var salary in salaryColumns ) 
            {
                if (salary.Text != null)
                {
                    int intSalary = Int32.Parse(salary.Text);
                    salaries.Add(intSalary);
                }
                else
                {
                    break;
                }
            }

            bool isAscending = true;
            for (int i = 1; i < salaries.Count; i++)
            {
                if (salaries[i] < salaries[i - 1])
                {
                    isAscending = false;
                    break;
                }
            }

            return isAscending;
        }

        public WebTables DeleteUserByName(string name)
        {
            Click(SelectorDeleteUserByName(name));
            return this;
        }

        public int CountFilledTableRows() 
        {
            IList<IWebElement> filledTableRows = FindElements("//div[@class='rt-tbody']//div[@role='row' and not(contains(@class,'-padRow'))]");
            return filledTableRows.Count;
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
