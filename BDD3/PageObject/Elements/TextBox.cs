using BoDi;
using OpenQA.Selenium;

namespace BDD3.PageObject.Elements
{
    public class TextBox : BaseClass
    {
        private IWebDriver webDriver;
        public TextBox(IObjectContainer conteiner) : base(conteiner)
        {
            webDriver = conteiner.Resolve<IWebDriver>();
        }

        private string InputFieldById(string id) => $"//input[@id='{id}']";
        private string TextareaFieldById(string id) => $"//textarea[@id='{id}']";
        private string EnteredUserDataById(string id) => $"//p[@id='{id}']";     
        private string submitButton = "//button[@id='submit']";

        public void GoToElementSection()
        {
            ScrollToElement(CategoryByName("Elements"));
            Click(CategoryByName("Elements"));
            Click("//div[text()='Elements']//following-sibling::div");
        }

        public TextBox GoToTextBox() 
        { 
            Click(SectionByName("Text Box")); 
            return this; 
        }

        public TextBox FillInForm(string fullName, string email, string currentAdress, string permanentAddress)
        {
            FillInputField(InputFieldById("userName"), fullName);
            FillInputField(InputFieldById("userEmail"), email);
            FillInputField(TextareaFieldById("currentAddress"), currentAdress);
            FillInputField(TextareaFieldById("permanentAddress"), permanentAddress);

            return this;
        }

        public TextBox Submit()
        {
            ScrollToElement(submitButton);
            Click(submitButton);
            return this;
        }

        public List<string> GetActualData()
        {
            List<string> actualData = new List<string>();
            string[] fieldLocators = { EnteredUserDataById("name"), EnteredUserDataById("email"), TextareaFieldById("currentAddress"), TextareaFieldById("permanentAddress") };
            foreach (string field in fieldLocators)
            {
                string[] arrayOfTotalActualData = GetElementText(field).Split(":");
                actualData.Add(arrayOfTotalActualData[1]);
            }
            return actualData;
        }
    }
}
