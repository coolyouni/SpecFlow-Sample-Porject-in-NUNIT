using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

public class InputFormSubmitPages
{
    private readonly IWebDriver _driver;
    public InputFormSubmitPages(IWebDriver driver)
    {
        _driver = driver;
    }
    private IWebElement inputFormSubmitLink => _driver.FindElement(By.XPath("//a[normalize-space()='Input Form Submit']"));
    private IWebElement submitbutton => _driver.FindElement(By.XPath("//*[@id=\"seleniumform\"]/div[6]/button"));
    private IWebElement name => _driver.FindElement(By.Name("name"));
    private IWebElement email => _driver.FindElement(By.Id("inputEmail4"));
    private IWebElement password => _driver.FindElement(By.Id("inputPassword4"));
    private IWebElement company => _driver.FindElement(By.Id("company"));
    private IWebElement websitename => _driver.FindElement(By.Id("websitename"));
    private IWebElement country => _driver.FindElement(By.XPath("//select[@name='country']"));
    private IWebElement city => _driver.FindElement(By.Id("inputCity"));
    private IWebElement adress1 => _driver.FindElement(By.Id("inputAddress1"));
    private IWebElement adress2 => _driver.FindElement(By.Id("inputAddress2"));
    private IWebElement state => _driver.FindElement(By.Id("inputState"));
    private IWebElement zipcode => _driver.FindElement(By.Id("inputZip"));
    private IWebElement successMessageBox => _driver.FindElement(By.XPath("//p[@class='success-msg hidden']"));    
    

    public void ClickOnInputFormSubmit() => inputFormSubmitLink.Click();

    public void WaitForSubmitButtonToAppear() =>
         new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(d => submitbutton.Displayed);
    public void ClickOnSubmitButton() 
    {
        WaitForSubmitButtonToAppear();
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click()", submitbutton);        
    }

    public void AssertErrorMessage(String expectedMessage)
    {
        //I don't understand logic for this 
        //var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        //IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//form[@method='post']")));
    }
    public void EnterName(string nameValue) => name.SendKeys(nameValue);
    public void EnterEmail(string emailValue) => email.SendKeys(emailValue);
    public void EnterPassword(string passwordValue) => password.SendKeys(passwordValue);
    public void EnterCompany(string companyValue) => company.SendKeys(companyValue);
    public void EnterWebsite(string websiteValue) => websitename.SendKeys(websiteValue);
    public void EnterCity(string cityValue) => city.SendKeys(cityValue);
    public void EnterAddress(string adress1Value, string adress2Value)
    {
        adress1.SendKeys(adress1Value);
        adress2.SendKeys(adress2Value);
    }   
    public void EnterState(string stateValue) => state.SendKeys(stateValue);
    public void EnterZipCode(string zipCdoeValue) => zipcode.SendKeys(zipCdoeValue);

    public void WaitForsuccessMessageBoxToAppear() =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(d => successMessageBox.Displayed);
    public void SuccessMessageFormSubmittion(string successMessageExpected) 
    {
        WaitForsuccessMessageBoxToAppear();
        string actualMessageValue = successMessageBox.GetAttribute("innerText");
        Assert.AreEqual(successMessageExpected, actualMessageValue);
    }
    public void Selectcountry(string countryValue)
    {
        SelectElement select = new SelectElement(country);
        select.SelectByValue(countryValue);
    }




}
