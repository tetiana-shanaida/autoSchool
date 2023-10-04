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

Scenario: WebTables section. Checking Salary order
	Given user is on WebTables page
	When user clicks on Salary column
	Then the values in the Salary column are sorted in ascending order

Scenario: WebTables section. Checking deleting second line
	Given user is on WebTables page
	When user delete second line(name is Alden)
	Then there are only two rows left in the table
	And the values in the Department column do not contain the value Compliance