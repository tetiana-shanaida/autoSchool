using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace BDD3.PageObject
{
    public class DriverFactory
    {
        public static IWebDriver webDriver { get; private set; }

        public static void InitializedDriver(string browserName)
        {
            if (webDriver == null)
            {
                switch (browserName)
                {
                    case "Chrome":
                        webDriver = new ChromeDriver();
                        break;
                    case "Firefox":
                        webDriver = new FirefoxDriver();
                        break;
                    case "Edge":
                        webDriver = new EdgeDriver();
                        break;
                    default:
                        throw new NotSupportedException($"Browser type '{browserName}' is not found.");
                }
            }
        }

        public static void CloseDriver()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
                webDriver = null;
            }
        }

        public static void NavigateTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }
    }
}
