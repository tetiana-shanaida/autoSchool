using OpenQA.Selenium;

namespace Page_Objects.PageObjectModel
{
    public class RegisterForm : BaseClass
    {
        private IWebDriver webDriver;
        public RegisterForm(IWebDriver webDriver) :base(webDriver)
        {
            this.webDriver = webDriver;
        }

        private string RegisterFormInputFieldByID (string id) => $"//input[@id='{id}']";
        private string FieldTitleByFor(string forAttribute) => $"//label[@for='{forAttribute}']";

        private string RegisterTitle = "//h2[text()='Register']";
        private string EmailInputField => RegisterFormInputFieldByID("reg_email");
        private string EmailFieldTitle => FieldTitleByFor("reg_email");
        private string PasswordInputField => RegisterFormInputFieldByID("reg_password");
        private string PasswordFieldTitle => FieldTitleByFor("reg_password");
        private string RegisterButton = "//input[@name='register']";

        public string GetTextFromRegisterButton()
        {
            return GetElementAttribute(By.XPath(RegisterButton), "value");
        }
    }
}
