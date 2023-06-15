using OpenQA.Selenium;

namespace Page_Objects.PageObjectModel
{
    public class RegisterForm
    {
        IWebDriver webDriver;
        public RegisterForm(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string RegisterFormInputFieldByID (string id) => $"//input[@id='{id}']";

        public IWebElement RegisterTitle => webDriver.FindElement(By.XPath("//h2[text()='Register']"));
        public IWebElement EmailInputField => webDriver.FindElement(By.XPath(RegisterFormInputFieldByID("reg_email")));
        public IWebElement PasswordInputField => webDriver.FindElement(By.XPath(RegisterFormInputFieldByID("reg_password")));
        public IWebElement RegisterButton => webDriver.FindElement(By.XPath("//input[@name='register']"));

        public string GetTextFromRegisterButton()
        {
            return RegisterButton.GetAttribute("value");
        }
    }
}
