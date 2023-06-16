using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Page_Objects.PageObjectModel
{
    public class LoginForm : BaseClass
    {
        private IWebDriver webDriver;
        
        public LoginForm(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }
        public string LoginFormInputFieldByID(string id) => $"//input[@id='{id}']";
        public string FieldTitleByFor(string forAttribute) => $"//label[@for='{forAttribute}']";

        public IWebElement LoginTitle => FindElement(By.XPath("//h2[text()='Login']"));
        public IWebElement UsernameInputField => FindElement(By.XPath(LoginFormInputFieldByID("username")));
        public IWebElement UsernameFieldTitle => FindElement(By.XPath(FieldTitleByFor("username")));
        public IWebElement PasswordInputField => FindElement(By.XPath(LoginFormInputFieldByID("password")));
        public IWebElement PasswordFieldTitle => FindElement(By.XPath(FieldTitleByFor("password")));

        public IWebElement LoginButton => FindElement(By.XPath("//input[@name='login']"));
        public IWebElement RememberMeCheckbox => FindElement(By.XPath(FieldTitleByFor("rememberme")));
        public IWebElement LostPasswordLink => FindElement(By.XPath("//a[contains(@href, '/lost-password/')]"));


        public string GetTextFromLostPassword()
        {
            return LostPasswordLink.Text;
        }

        public string GetTextFromRememberMe() 
        {
            return RememberMeCheckbox.Text;
        }

        public void Login(string usernameOrEmail, string password)
        {
            UsernameInputField.Clear();
            UsernameInputField.SendKeys(usernameOrEmail);

            PasswordInputField.Clear();
            PasswordInputField.SendKeys(password);

            LoginButton.Click();
        }
    }
}
