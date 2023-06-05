using System;

public class ParameterizedXPath
{
    public string CategoryItemByName(string categoryName) => $"//li[contains(@class, 'cat-item')]/a[text()='{categoryName}']";

    public string MenuItemByName(string menuName) => $"//li[contains(@class, 'menu-item')]/a[text()='{menuName}']";

    public string OrderByValue(string itemValue) => $"//select[@class='orderby']/option[@value='{itemValue}']";

    public string BookByTitle(string BookTitle) => $"//h3[text()='{BookTitle}']/parent::a";

    public string ReadMore(string bookTitle) => $"//h3[text()='{bookTitle}']//..//following-sibling::a[text()='Read more'";

    public string SocialNetwork(string socialNetworkName) => $"/a[@title='{socialNetworkName}']/i";
}
