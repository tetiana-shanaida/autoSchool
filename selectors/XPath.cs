using NUnit.Framework.Internal;

namespace selectors
{
    public class XPath
    {
        string search = "//input[@title='Search']";

        string testCases = "//a[text()='Test Cases']";       
        string TestCases = "//li[contains(@class, 'menu-item')]/a[text()='Test Cases']";

        string pullDownButton = "//a[@class='pull-down']";
        string filter = "//button[text()='Filter']";

        string javaScript = "//a[text()='JavaScript']";     
        string JavaScript = "//li[contains(@class, 'cat-item')]/a[text()='JavaScript']";

        string Android = "//h3[text()='Android Quick Start Guide']/parent::a";
        string android = " //li[contains(@class, 'product_tag-android')]/descendant::h3[text()='Android Quick Start Guide']/..";       

        string twoHundredEighty = " //h3[text()='HTML5 Forms']/following-sibling::span[contains(@class, 'price')]/span";
        string sortByNewness = " //select[@class='orderby']/option[@value='date']";
        string email = "//input[@type='email']";
        string twoThousandTwentyThree = " //div[@class='footer-text-inner']/div[@class='one']";
    }
}