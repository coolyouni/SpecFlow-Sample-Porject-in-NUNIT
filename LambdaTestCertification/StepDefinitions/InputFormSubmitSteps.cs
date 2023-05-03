using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Xml.Linq;

namespace LambdaTestCertification.StepDefinitions
{
    [Binding]
    public class InputFormSubmitSteps
    {
        private readonly InputFormSubmitPages _lambdaTest;
        public string message;
        public InputFormSubmitSteps(IObjectContainer objectContainer)
        {
            var lambdaTestDriver = objectContainer.Resolve<LambdaTestDriver>("lambdaTestDriver");
            _lambdaTest = new InputFormSubmitPages(lambdaTestDriver.Current);
        }

        [Given(@"I click Input Form Submit under Input Forms")]
        public void GivenIClickInputFormSubmitUnderInputForms() => _lambdaTest.ClickOnInputFormSubmit();


        [When(@"I click Submit button")]
        public void WhenIClickSubmitButton() => _lambdaTest.ClickOnSubmitButton();


        [Then(@"I should see an error message ""([^""]*)""")]
        public void ThenIShouldSeeAnErrorMessage(string message) => _lambdaTest.AssertErrorMessage(message);


        [When(@"I fill in the Name field with ""([^""]*)""")]
        public void WhenIFillInTheNameFieldWith(string name) => _lambdaTest.EnterName(name);

        [When(@"I fill in the Email field with ""([^""]*)""")]
        public void WhenIFillInTheEmailFieldWith(string email) => _lambdaTest.EnterEmail(email);       

        [When(@"I fill in the Password field with ""([^""]*)""")]
        public void WhenIFillInThePasswordFieldWith(string password) => _lambdaTest.EnterPassword(password);        

        [When(@"I fill in the company field with ""([^""]*)""")]
        public void WhenIFillInTheCompanyFieldWith(string company) => _lambdaTest.EnterCompany(company);   
       
        [When(@"I fill in the website field with ""([^""]*)""")]
        public void WhenIFillInTheWebsiteFieldWith(string website) => _lambdaTest.EnterWebsite(website);       

        [When(@"I select ""([^""]*)"" united States from the Country drop-down")]
        public void WhenISelectUnitedStatesFromTheCountryDrop_Down(string country) => _lambdaTest.Selectcountry(country);

        [When(@"I fill in the City field with ""([^""]*)""")] 
        public void WhenIFillInTheCityFieldWith(string city) => _lambdaTest.EnterCity(city);         

        [When(@"I fill in the Address(.*) field with ""([^""]*)""")]
        public void WhenIFillInTheAddressFieldWith(string adress1, string address2) => _lambdaTest.EnterAddress(adress1, address2);       

        [When(@"I fill in the state field with ""([^""]*)""")]
        public void WhenIFillInTheStateFieldWith(string state) => _lambdaTest.EnterState(state);         


        [When(@"I fill in the Zip Code field with ""([^""]*)""")]
        public void WhenIFillInTheZipCodeFieldWith(string zipcdoe) => _lambdaTest.EnterZipCode(zipcdoe);

        [Then(@"I should see a success message ""([^""]*)""")]
        public void ThenIShouldSeeASuccessMessage(string successMessage) => _lambdaTest.SuccessMessageFormSubmittion(successMessage);

    }
}