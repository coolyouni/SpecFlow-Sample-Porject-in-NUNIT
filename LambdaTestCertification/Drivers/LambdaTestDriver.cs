using OpenQA.Selenium;

public class LambdaTestDriver : IDisposable
{
    private readonly Lazy<IWebDriver> _lambdaDriverLazy;
    private bool _isDisposed;

    public LambdaTestDriver(IWebDriver webDriver)
    {
        _lambdaDriverLazy = new Lazy<IWebDriver>(() => webDriver);
    }

    public IWebDriver Current => _lambdaDriverLazy.Value;

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        if (_lambdaDriverLazy.IsValueCreated)
        {
            Current.Quit();
        }

        _isDisposed = true;
    }
}
