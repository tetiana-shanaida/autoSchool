using OpenQA.Selenium;

namespace Page_Objects.PageObjectModel
{
    public class LoginForm : BaseClass
    {
        private IWebDriver webDriver;
        
        public LoginForm(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }
        private string LoginFormInputFieldByID(string id) => $"//input[@id='{id}']";
        private string FieldTitleByFor(string forAttribute) => $"//label[@for='{forAttribute}']";

        private string LoginTitle = "//h2[text()='Login']";
        private string UsernameInputField => LoginFormInputFieldByID("username");
        private string UsernameFieldTitle => FieldTitleByFor("username");
        private string PasswordInputField => LoginFormInputFieldByID("password");
        private string PasswordFieldTitle => FieldTitleByFor("password");

        private string LoginButton = "//input[@name='login']";
        private string RememberMeCheckbox => FieldTitleByFor("rememberme");
        private string LostPasswordLink = "//a[contains(@href, '/lost-password/')]";


        public string GetTextFromLostPassword()
        {
            return FindElement(By.XPath(LostPasswordLink)).Text;
        }

        public string GetTextFromRememberMe() 
        {
            return FindElement(By.XPath(RememberMeCheckbox)).Text;
        }

        public void Login(string usernameOrEmail, string password)
        {
            FindElement(By.XPath(UsernameInputField)).Clear();
            FillInputField(By.XPath(UsernameInputField), usernameOrEmail);

            FindElement(By.XPath(PasswordInputField)).Clear();
            FillInputField(By.XPath(PasswordInputField), password);

            Click(By.XPath(LoginButton));
        }
    }
}
