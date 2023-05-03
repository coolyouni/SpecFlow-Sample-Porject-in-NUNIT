using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

[Binding]
public class SharedWebHooks
{
    private readonly IObjectContainer _objectContainer;

    public SharedWebHooks(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void SetUp(ScenarioContext scenarioContext)
    {
        // Create a Chrome driver instance and register it in the object container with a name "chrome"
        var browserName = scenarioContext.ScenarioInfo.Tags.Contains("chrome") ? "chrome" : "edge";
        if (browserName == "chrome")
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            var chromeDriver = new ChromeDriver(chromeOptions);
            var lambdaTestDriver = new LambdaTestDriver(chromeDriver);
            _objectContainer.RegisterInstanceAs<LambdaTestDriver>(lambdaTestDriver, "lambdaTestDriver");
        }
        else if (browserName == "edge")
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            var edgeOptions = new EdgeOptions();
            var edgeDriver = new EdgeDriver(edgeOptions);
            var lambdaTestDriver = new LambdaTestDriver(edgeDriver);
            _objectContainer.RegisterInstanceAs<LambdaTestDriver>(lambdaTestDriver, "lambdaTestDriver");
        }
    }

    [AfterScenario]
    public void TearDown()
    {
        var lambdaTestDriver = _objectContainer.Resolve<LambdaTestDriver>("lambdaTestDriver");
        lambdaTestDriver.Dispose();
    }
}
