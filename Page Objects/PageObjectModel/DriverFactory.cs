using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Page_Objects.PageObjectModel
{
    public class DriverFactory
    {
        public IWebDriver webDriver { get; private set; }

        public void InitializeDriver(string browserName)
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
            //return webDriver;
        }

        public void CloseDriver()
        {
            if (webDriver != null)
            {
                webDriver.Quit();
                webDriver = null;
            }
        }

        public void NavigateTo(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }
    }
}

