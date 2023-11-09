using BoDi;
using OpenQA.Selenium;

namespace BDD3.PageObject.Interactions
{
    public class Selectable:BaseClass
    {
        private IWebDriver webDriver;
        public Selectable(IObjectContainer conteiner) : base(conteiner)
        {
            webDriver = conteiner.Resolve<IWebDriver>();
        }

        private string GroupItemByText (string text) => $"//li[text()='{text}']";
        private string TabByTitle(string title) => $"//a[@id='demo-tab-{title}']";
        private string selectedItemsLocator = "//li[contains(@class, 'list-group-item active')]";

        public void GoToInteractionsCategory()
        {
            ScrollToElement(CategoryByName("Interactions"));
            Click(CategoryByName("Interactions"));
        }

        public void GoToSelectableSection()
        {
            Click(SectionByName("Selectable"));
        }

        public void OpenTab(string title)
        {
            Click(TabByTitle(title));
        }

        public void SelectItem(string number)
        {
            Click(GroupItemByText(number));
        }

        public List<string> GetSelectedItems()
        {
            List<string> actualValuesOfItems = new List<string>();
            IList<IWebElement> selectedItems = FindElements(selectedItemsLocator);
            foreach (IWebElement selectedItem in selectedItems)
            {
                actualValuesOfItems.Add(selectedItem.Text);
            }
            return actualValuesOfItems;
        }

    }
}
