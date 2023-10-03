using OpenQA.Selenium;
using System.Xml.Linq;

namespace BDD3.PageObject.Elements
{
    public class TextBox : BaseClass
    {
        private IWebDriver webDriver;

        public TextBox(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        private string elementCategory => CategoryByName("Elements");
        private string textBoxSection => SectionByName("Text Box");
        private string InputFieldById(string id) => $"//input[@id='{id}']";
        private string TextareaFieldById(string id) => $"//textarea[@id='{id}']";
        private string EnteredUserDataById(string id) => $"//p[@id='{id}']";

        private string FullNameInputField => InputFieldById("userName");
        private string EmailInputField => InputFieldById("userEmail");
        private string CurrentAddressTextField => TextareaFieldById("currentAddress");
        private string PermanentAddressTextField => TextareaFieldById("permanentAddress");
        private string submitButton = "//button[@id='submit']";
        private string EnteredUserName => EnteredUserDataById("name");
        private string EnteredUserEmail => EnteredUserDataById("email");
        private string EnteredUserCurrentAddress => EnteredUserDataById("currentAddress");
        private string EnteredUserPermanentAddress => EnteredUserDataById("permanentAddress");

        public List<string> expectedData = new List<string>();
        public List<string> actualData = new List<string>();

        public TextBox GoToElementSection()
        {
            Click(elementCategory);
            Click("//div[text()='Elements']//following-sibling::div");
            return this;
        }

        public TextBox GoToTextBox() { Click(textBoxSection); return this; }

        public TextBox FillInForm(string fullName, string email, string currentAdress, string permanentAddress)
        {
            FillInputField(FullNameInputField, fullName);
            FillInputField(EmailInputField, email);
            FillInputField(CurrentAddressTextField, currentAdress);
            FillInputField(PermanentAddressTextField, permanentAddress);

            IWebElement element = FindElement(submitButton);
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            Click(submitButton);

            expectedData.AddRange(new[] { fullName, email, currentAdress, permanentAddress });

            return this;
        }

        public void GetActualData()
        {
            string[] fieldLocators = {EnteredUserName, EnteredUserEmail, EnteredUserCurrentAddress, EnteredUserPermanentAddress};
            foreach (string field in fieldLocators)
            {
                string[] arrayOfTotalActualData = GetElementText(field).Split(":");
                actualData.Add(arrayOfTotalActualData[1]);
            }
        }
    }
}
