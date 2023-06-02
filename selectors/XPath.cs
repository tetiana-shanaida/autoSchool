using NUnit.Framework.Internal;

namespace selectors
{
    public class XPath
    {
        string search = "//input[@title='Search']";
        string testCases = "//li[@id='menu-item-224']/child::a";
        string pullDownButton = "//a[@class='pull-down']";
        string filter = "//button[@class='button']";
        string javaScript = "//li[contains(@class, 'cat-item-21')]";
        string android = "//li[contains(@class, 'product_tag-android')]/child::a[@class='woocommerce-LoopProduct-link']";
        string twoHundredEighty =  "//li[contains(@class, 'post-181')]/descendant::span[contains(@class, 'woocommerce-Price-amount')]";
        string sortByNewness = "//option[@value='date']";
        string email = "//input[@type='email']";
        string twoThousandTwentyThree = "//div[@class='one']";
    }
}