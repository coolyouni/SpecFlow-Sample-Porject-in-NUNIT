using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

public class DragDropSlidersPages
{
    private readonly IWebDriver _driver;
    public DragDropSlidersPages(IWebDriver driver)
    {
        _driver = driver;
    }
    private IWebElement dragDropSliderLink => _driver.FindElement(By.XPath("//a[normalize-space()='Drag & Drop Sliders']"));
    private IWebElement rangeInput => _driver.FindElement(By.XPath("//*[@id=\"slider3\"]/div/input"));
    private IWebElement rangeValue => _driver.FindElement(By.Id("rangeSuccess"));
    
    public void ClickOnDragAndDropSliders() => dragDropSliderLink?.Click();

    public void WaitForDragAndDropBoxToAppear() =>
        new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(d => rangeInput.Displayed);
    public void DragAndDropValue(int drageValue,int dropValue)
    {
        WaitForDragAndDropBoxToAppear();

        int startX = rangeInput.Location.X;
        int endX = startX + rangeInput.Size.Width;

        // Calculate the desired position based on the range value
        int desiredX = startX + (int)Math.Round((43.00 / 100) * (endX - startX));

        // Use Actions class to drag and drop the slider
        Actions actions = new Actions(_driver);
        actions.MoveToElement(rangeInput)
               .ClickAndHold()
               .MoveByOffset(desiredX - startX, 0)
               .Release()
               .Perform();
    }

    public void ValidateRangeValue(string expectedRange)
    {
        string actualMessageValue = rangeValue.GetAttribute("innerText");
        Assert.AreEqual(expectedRange, actualMessageValue);
    }

}
