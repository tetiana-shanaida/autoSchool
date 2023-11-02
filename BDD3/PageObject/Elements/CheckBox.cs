using OpenQA.Selenium;

namespace BDD3.PageObject.Elements
{
    public class CheckBox:BaseClass
    {
        private IWebDriver webDriver;

        public CheckBox(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        private string ExpandFolderByName(string name) => $"//label[@for='tree-node-{name}']//preceding-sibling::button[@title='Toggle']";
        private string SelectFolderOrItemByName(string name) => $"//label[@for='tree-node-{name}']//span[@class='rct-checkbox']";

        public CheckBox GoToCheckBoxSection()
        {
            Click(SectionByName("Check Box"));

            return this;
        }

        public CheckBox ExpandFolder(string folderName)
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", FindElement(SelectFolderOrItemByName(folderName)));
            Click(ExpandFolderByName(folderName));
            return this;
        }

        public CheckBox SelectFolderOrItem(string folderName) 
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", FindElement(SelectFolderOrItemByName(folderName)));
            Click(SelectFolderOrItemByName(folderName)); 
            return this; 
        }

        public string ActualText()
        {
            List<string> actualTextList = new List<string>();
            IList<IWebElement> elements = FindElements("//div[@id='result']/span");

            foreach (IWebElement element in elements)
            {
                actualTextList.Add(element.Text);
            }

            return string.Join(" ", actualTextList);
        }
    }
}
