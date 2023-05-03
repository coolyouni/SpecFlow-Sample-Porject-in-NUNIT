using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LambdaTestCertification.StepDefinitions
{
    [Binding]
    public class SimpleFormDemoSteps
    {
        private readonly SimpleFormDemoPages _lambdaTest;
        public string message;
        public SimpleFormDemoSteps(IObjectContainer objectContainer)
        {
            var lambdaTestDriver = objectContainer.Resolve<LambdaTestDriver>("lambdaTestDriver");
            _lambdaTest = new SimpleFormDemoPages(lambdaTestDriver.Current);
        }

        [Given(@"I navigate to ""([^""]*)""")]
        public void GivenINavigateTo(string url) => _lambdaTest.GoToUrl(url);

        [Given(@"I click Simple Form Demo under Input Forms")]
        public void GivenIClickSimpleFormDemoUnderInputForms() => _lambdaTest.ClickOnSimpleFormDemo();

        [Then(@"the URL should contain ""([^""]*)""")]
        public void ThenTheURLShouldContain(string urlcontains) => _lambdaTest.verifyurlcontains(urlcontains);

        [When(@"I set the message to ""([^""]*)""")]
        public void WhenISetTheMessageTo(string welcomeMessage)
        {
            message = welcomeMessage;
            _lambdaTest.addMessageValue(welcomeMessage);
        }

        [When(@"I click Get Checked Value")]
        public void WhenIClickGetCheckedValue()
        {
            _lambdaTest.ClickOnGetCheckedValue();
        }

        [Then(@"the message in the right-hand panel should be ""([^""]*)""")]
        public void ThenTheMessageInTheRight_HandPanelShouldBe(string value) => _lambdaTest.MessageValueShouldBeMatch(message);
    }
}