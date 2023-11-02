Feature: Elements

Background:
	When user open the element category

Scenario: Fill in TextBox form with correct data
	When user goes to text box section
	When user enters personal data: "Lubov", "tanya@gmail.com", "Ternopil", "Odessa" in TextBox form
	And user submits form
	Then entered data are displayed in the appeared table

Scenario: CheckBox section
	When user goes to checkbox section
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

Scenario: WebTables section. Check sort by salary column
	Given user is on the WebTables page
	When user sorts users' data by "Salary" column in the table
	Then users' data are sorted in "ascending" order by "Salary" column

Scenario: WebTables section. Checking deleting user data
	Given user is on the WebTables page
	When user deletes user with name "Alden"
	Then there are "2" users left in the table
	And the "Compliance" value is deleted from the Department column

Scenario: Buttons section
	Given user is on Buttons page
	When user clicks on button "Right click me"
	Then the appropriate message is displayed