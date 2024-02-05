using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
namespace LocationMap
{
    public class Tests
    {
        private IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            // Ініціалізація веб-драйвера перед кожним тестом
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://54.173.239.233/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [TearDown]
        public void Teardown()
        {
            // Закриття веб-драйвера після кожного тесту
            driver.Quit();
        }
        private int GetRandomNumber()
        {
            // Генерація випадкового числа від 1 до 100
            Random random = new Random();
            return random.Next(1, 1000002);
        }

        [Test]
        public void LoginTest()
        {
            // Відкриття веб-сайту
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
            // Логін
            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("maestro+maestro-super-admin-00@locationtech.com");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("Find1tFastN0w+super-admin-00");
            driver.FindElement(By.XPath("//button[@name='login']")).Click();

        
          
            driver.Navigate().GoToUrl("http://54.173.239.233/admin/core/fixedlocation/");

      

            //for (int i = 0; i < 100; i++)
            //{

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class=\"grp-add-link grp-state-focus\"]")));

                driver.FindElement(By.XPath("//a[@class=\"grp-add-link grp-state-focus\"]")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name=\"name\"]")));

                driver.FindElement(By.XPath("//input[@name=\"name\"]")).SendKeys("location");
                driver.FindElement(By.XPath("//span[@aria-labelledby=\"select2-id_client-container\"][1]")).Click();
                driver.FindElement(By.XPath("//input[@class=\"select2-search__field\"]")).SendKeys("nix");
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='select2-results']//li")));
                Thread.Sleep(6000);
                driver.FindElement(By.XPath("//span[@class='select2-results']//li")).Click();
                Thread.Sleep(6000);


                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@aria-labelledby='select2-id_org-container']")));
                ////IWebElement orgContainer = driver.FindElement(By.XPath("//span[@aria-labelledby='select2-id_org-container']"));
                ////((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", orgContainer);
                //driver.FindElement(By.XPath("//span[@aria-labelledby='select2-id_org-container']")).Click();
                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class=\"select2-search__field\"]")));

                //driver.FindElement(By.XPath("//input[@class=\"select2-search__field\"]")).SendKeys("nix");
                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(@class, 'select2-results__option')]")));

                //driver.FindElement(By.XPath("//li[contains(@class, 'select2-results__option')]")).Click();

                //driver.FindElement(By.XPath("//input[@name=\"building_tag\"]")).SendKeys("nix hotel");
                //driver.FindElement(By.XPath("//input[@name='floor_tag']")).SendKeys("2");

                //string randomNumber = GetRandomNumber().ToString();

                //IWebElement zoneTagInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='zone_tag']")));
                //zoneTagInput.Clear();
                //zoneTagInput.SendKeys(randomNumber);
                //driver.FindElement(By.XPath("//input[@name='_save']")).Click();

                //Thread.Sleep(1000);


            //}
        }
    }
}