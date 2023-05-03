using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

public class SimpleFormDemoPages
{
    private readonly IWebDriver _driver;
    public SimpleFormDemoPages(IWebDriver driver)
    {
        _driver = driver;
    }
    private IWebElement simpleFormDemoLink => _driver.FindElement(By.XPath("//a[normalize-space()='Simple Form Demo']"));
    private IWebElement inputMessageBox => _driver.FindElement(By.Id("user-message"));
    private IWebElement getCheckedValueButton => _driver.FindElement(By.Id("showInput"));
    private IWebElement messageValue => _driver.FindElement(By.Id("message"));
    


    public void GoToUrl(string url) => _driver.Navigate().GoToUrl(url);
    public void ClickOnSimpleFormDemo() => simpleFormDemoLink?.Click();

    public void verifyurlcontains(string expectedUrl)
    {
        string currentUrl = _driver.Url;       
        if (!currentUrl.Contains(expectedUrl))
        {
            throw new AssertionException($"Expected URL to contain '{expectedUrl}', but actual URL is '{currentUrl}'");
        }
    }
    public void WaitForMessageBoxToAppear() =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(d => inputMessageBox.Displayed);
    public void addMessageValue(string message)
    {
        WaitForMessageBoxToAppear();
        inputMessageBox.SendKeys(message);
    }
    public void ClickOnGetCheckedValue() => getCheckedValueButton.Click();

    public void MessageValueShouldBeMatch(string expectedMessageValue)     
    { 
        string actualMessageValue= messageValue.GetAttribute("innerText");
        Assert.AreEqual(expectedMessageValue, actualMessageValue);
    }
}
