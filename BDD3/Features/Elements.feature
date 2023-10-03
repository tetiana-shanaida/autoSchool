Feature: Elements

Background:
	Given open the browser
	Given user is on main page
	When user cliks on element category

Scenario: Fill in TextBox with correct data
	When user clicks on text box section
	When user enters data
	Then entered data are displayed in appeared table

Scenario: CheckBox section
	When user clicks on check box section
	When user expand home folder
	When user select Desktop folder
	When user select Angular and Veu from WorkSpace folder
	When user expandOffice folder and clicks on each element in folder
	When user expand Downloads folder and select it
	Then user see text You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile