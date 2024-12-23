# SpecFlow Project
This project uses SpecFlow for writing and running automated tests for LambdaTest website's UI. The codebase includes hooks, drivers, and steps files for executing tests on different browsers and different scenarios.

Installation

    Clone the repository to your local machine.
    Install the necessary packages by running the following command:
    dotnet restore
    
    Set up WebDriver Manager by running the following command:
    dotnet tool install selenium.webdrivermanager
    
    Execution:

The tests can be executed by running the following command:
dotnet test

Features
Simple Form Demo

The SimpleFormDemoSteps file contains the steps for testing the Simple Form Demo page of the LambdaTest website. 

Input Form Submit

The InputFormSubmitSteps file contains the steps for testing the Input Form Submit page of the LambdaTest website.

Drag and Drop Sliders Functionality

The DragDropSlidersSteps file contains the steps for testing the Drag and Drop Sliders Functionality page of the LambdaTest website. 

Hooks and Drivers

The project includes the LambdaTestDriver class and the SharedWebHooks class for setting up and tearing down the drivers and hooks for executing the tests. The LambdaTestDriver class is responsible for managing the lifecycle of the WebDriver instance. The SharedWebHooks class is responsible for creating the WebDriver instance and registering it with the Object Container. It also handles the disposal of the WebDriver
