using OpenQA.Selenium;

namespace Page_Objects.PageObjectModel
{
    public class LoginForm
    {
        IWebDriver webDriver;
        public LoginForm(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public string LoginFormInputFieldByID(string id) => $"//input[@id='{id}']";

        public IWebElement LoginTitle => webDriver.FindElement(By.XPath("//h2[text()='Login']"));
        public IWebElement UsernameInputField => webDriver.FindElement(By.XPath(LoginFormInputFieldByID("username")));
        public IWebElement PasswordInputField => webDriver.FindElement(By.XPath(LoginFormInputFieldByID("password")));
        public IWebElement LoginButton => webDriver.FindElement(By.XPath("//input[@name='login']"));
        public IWebElement RememberMeCheckbox => webDriver.FindElement(By.XPath("//label[@for='rememberme']"));
        public IWebElement LostPasswordLink => webDriver.FindElement(By.XPath("//a[contains(@href, '/lost-password/')]"));


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
