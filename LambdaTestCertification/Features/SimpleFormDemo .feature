Feature: SimpleFormDemo

 @chrome
 
 Scenario: Simple Form Demo
   Given I navigate to "https://www.lambdatest.com/selenium-playground"
   And I click Simple Form Demo under Input Forms
   Then the URL should contain "simple-form-demo"
   When I set the message to "Welcome to LambdaTest"
   And I click Get Checked Value
   Then the message in the right-hand panel should be "Welcome to LambdaTest"