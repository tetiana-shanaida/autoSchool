using System;

public class ParameterizedXPath
{
    public string CategoryItemByName(string CategoryName) => $"//ul[@class='product-categories']/li[contains(@class, 'cat-item')]/a[text()='{CategoryName}']"

    public string MenuItemByName(string MenuName) => $"//ul[@class='main-nav']/li[contains(@class, 'menu-item')]/a[text()='{MenuName}']"

    public string OrderByValue(string ItemValue) => $"//select[@class='orderby']/option[@value='{ItemValue}']"

    public string BookByTitle(string BookTitle) => $"//li[contains(@class, 'product type-product')]/descendant::h3[text()='{BookTitle}']/parent::a"

    public string ReadMore(string BookTitle) => $"//li[contains(@class, 'product type-product')]/descendant::h3[text()='{BookTitle}']/parent::a/following-sibling::a"

    public string SocialNetwork(string SocialNetworkName) => $"//li[contains(@class, 'social-link-item')]/a[@title='{SocialNetworkName}']/i"
}
