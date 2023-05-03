Feature: Input Form Submit
 @chrome
 
Scenario: Scenario: Submitting the form with and without filling the fields
	Given I navigate to "https://www.lambdatest.com/selenium-playground"
	And I click Input Form Submit under Input Forms
	When I click Submit button
	Then I should see an error message "Please fill in the fields"
	When I fill in the Name field with "younas"
	And I fill in the Email field with "younasLambdaTest@mailinator.com"
	And I fill in the Password field with "123456@lambdaTest"
	And I fill in the company field with "TEO"
	And I fill in the website field with "https://www.lambdatest.com/selenium-playground"
	And I select "US" united States from the Country drop-down
	And I fill in the City field with "Anytown"
	And I fill in the Address1 field with "123 Main St."	
	And I fill in the Address2 field with "New Jersy."
	And I fill in the state field with "Texas"	
	And I fill in the Zip Code field with "12345"
	And I click Submit button
	Then I should see a success message "Thanks for contacting us, we will get back to you shortly."
