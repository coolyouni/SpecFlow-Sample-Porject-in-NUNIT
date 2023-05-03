Feature: Drag and Drop Sliders Functionality

 @chrome
 
 Scenario: Drag and Drop Slider to Set Range Value
   Given I navigate to "https://www.lambdatest.com/selenium-playground"
   When I click on Drag & Drop Sliders  
   And I select the slider Default value "15" and  drag the slider to set the range value to "95"  
   Then I should see the range value as "95" 