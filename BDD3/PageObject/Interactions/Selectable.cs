using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace BDD3.PageObject.Interactions
{
    public class Selectable:BaseClass
    {
        private IWebDriver webDriver;

        public Selectable(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        private string GroupItemByText (string text) => $"//li[text()={text}]";
        private string TabByTitle(string title) => $"//a[@id='demo-tab-{title}']";

        public void GoToInteractionsCategory()
        {
            CategoryByName("Interactions");
        }

        public void GoToSelectableSection()
        {
            SectionByName("Selectable");
        }

        public void OpenTab(string title)
        {
            Click(TabByTitle(title));
        }

        public void SelectItem(string number)
        {
            Click(GroupItemByText(number));
        }
    }
}
