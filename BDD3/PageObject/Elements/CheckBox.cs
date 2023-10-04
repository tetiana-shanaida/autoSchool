using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;

namespace BDD3.PageObject.Elements
{
    public class CheckBox:BaseClass
    {
        private IWebDriver webDriver;

        public CheckBox(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        private string ElementCategory => CategoryByName("Elements");
        private string CheckBoxSection => SectionByName("Check Box");

        private string ExpandFolderByForAttribute(string forAttribute) => $"//label[@for='{forAttribute}']//preceding-sibling::button[@title='Toggle']";
        private string SelectCheckboxByForAttribute(string forAttribute) => $"//label[@for='{forAttribute}']//span[@class='rct-checkbox']";

        private string SelectorToExpandHomeFolder => ExpandFolderByForAttribute("tree-node-home");
        private string ExpandDocumentFolder => ExpandFolderByForAttribute("tree-node-documents");
        private string ExpandWorkspaceFolder => ExpandFolderByForAttribute("tree-node-workspace");
        private string SelectorToExpandOfficeFolder => ExpandFolderByForAttribute("tree-node-office");
        private string ExpandDownloadsFolder => ExpandFolderByForAttribute("tree-node-downloads");
        private string SelectorToSelectDesktop => SelectCheckboxByForAttribute("tree-node-desktop");
        private string SelectAngular => SelectCheckboxByForAttribute("tree-node-angular");
        private string SelectVeu => SelectCheckboxByForAttribute("tree-node-veu");
        private string SelectPublic => SelectCheckboxByForAttribute("tree-node-public");
        private string SelectPrivate => SelectCheckboxByForAttribute("tree-node-private");
        private string SelectClassified => SelectCheckboxByForAttribute("tree-node-classified");
        private string SelectGeneral => SelectCheckboxByForAttribute("tree-node-general");
        private string SelectDownloads => SelectCheckboxByForAttribute("tree-node-downloads");

        public string expectedText = "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile";
        public string actualText;

        public CheckBox GoToCheckBoxSection()
        {
            Click(CheckBoxSection);

            return this;
        }

        public CheckBox ExpandHomeFolder()
        {
            Click(SelectorToExpandHomeFolder);
            return this;
        }

        public CheckBox SelectDesktop() 
        { 
            Click(SelectorToSelectDesktop); 
            return this; 
        }

        public CheckBox SelectAngularAndVeu()
        {
            Click(ExpandDocumentFolder);
            Click(ExpandWorkspaceFolder);
            Click(SelectAngular);
            Click(SelectVeu);

            return this;
        }

        public CheckBox ExpandOfficeFolder()
        {
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", FindElement(SelectorToExpandOfficeFolder));
            Click(SelectorToExpandOfficeFolder);
            Click(SelectPublic);
            Click(SelectPrivate);
            Click(SelectClassified);
            Click(SelectGeneral);

            return this;
        }

        public CheckBox DownloadFolder()
        {
            Click(ExpandDownloadsFolder);
            Click(SelectDownloads);

            return this;
        }

        public string ActualText()
        {
            List<string> actualTextList = new List<string>();
            IList<IWebElement> elements = webDriver.FindElements(By.XPath("//div[@id='result']/span"));

            foreach (IWebElement element in elements)
            {
                actualTextList.Add(element.Text);
            }

            actualText = string.Join(" ", actualTextList);
            return actualText;
        }
    }
}
