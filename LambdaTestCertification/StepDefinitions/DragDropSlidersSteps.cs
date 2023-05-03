using BoDi;

namespace LambdaTestCertification.StepDefinitions
{
    [Binding]
    public class DragDropSlidersSteps
    {
        private readonly DragDropSlidersPages _lambdaTest;
        public string message;
        public DragDropSlidersSteps(IObjectContainer objectContainer)
        {
            var lambdaTestDriver = objectContainer.Resolve<LambdaTestDriver>("lambdaTestDriver");
            _lambdaTest = new DragDropSlidersPages(lambdaTestDriver.Current);
        }      

        [When(@"I click on Drag & Drop Sliders")]
        public void WhenIClickOnDragDropSliders() => _lambdaTest.ClickOnDragAndDropSliders();

        [When(@"I select the slider Default value ""([^""]*)"" and  drag the slider to set the range value to ""([^""]*)""")]
        public void WhenISelectTheSliderDefaultValueAndDragTheSliderToSetTheRangeValueTo(int valueDrag, int valueDrop) =>
            _lambdaTest.DragAndDropValue(valueDrag, valueDrop);

        [Then(@"I should see the range value as ""([^""]*)""")]
        public void ThenIShouldSeeTheRangeValueAs(string expectedValue) => _lambdaTest.ValidateRangeValue(expectedValue);        
    }
}