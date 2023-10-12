Feature: Elements

Background:
	Given open the browser
	Given user is on the main page
	When user opens the element category

Scenario: Fill in TextBox form with correct data
	When user goes to text box section
	When user enters personal data: "Lubov", "tanya@gmail.com", "Ternopil", "Odessa" in form
	And user submits form
	Then entered data are displayed in the appeared table

Scenario: CheckBox section
	When user goes to check box section
	When user expands "home" folder
	When user selects "desktop" folder
	When user expands "documents" folder
	When user expands "workspace" folder
	And user selects "angular" folder
	And user selects "veu" folder
	When user expands "office" folder
	And user selects "public" folder
	And user selects "private" folder
	And user selects "classified" folder
	And user selects "general" folder
	When user expands "downloads" folder
	And user selects "downloads" folder
	Then user see text: "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile"

Scenario: WebTables section. Checking Salary order
	Given user is on the WebTables page
	When user clicks on "Salary" column
	Then the values in the "Salary" column are sorted in "ascending" order

Scenario: WebTables section. Checking deleting second line
	Given user is on the WebTables page
	When user deletes "Alden" line
	Then there are only "2" rows left in the table
	And the values in the Department column do not contain the value "Compliance"

Scenario: Buttons section
	Given user is on Buttons page
	When user clicks on button "Button name"
	Then the appropriate message is displayed