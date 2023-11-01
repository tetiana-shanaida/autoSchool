Feature: Widgets

Background:
	Given user is on main page
	When user goes to the Widgets category

Scenario: Section Auto Complete.Check autocomplete to one letter
	Given user is on auto-complete page
	When user types "g" in the Type multiple color names field
	Then autocomplete suggests "3" variants 
	And each variants contains "g" letter

Scenario: Section Auto Complete. Check autocomplete after deleting search words
	Given user is on auto-complete page
	When user enters color "Red" in the Type multiple color names field
	And user enters color "Yellow" in the Type multiple color names field
	And user enters color "Green" in the Type multiple color names field
	And user enters color "Blue" in the Type multiple color names field
	And user enters color "Purple" in the Type multiple color names field
	When user deletes color "Yellow"
	And user deletes color "Purple" 
	Then "Red" color remained in the field
	And "Green" color remained in the field
	And "Blue" color remained in the field

Scenario: Progress Bar
	Given user is on Progress Bar page
	When user clicks on Start button to start progress bar
	And user waits until progress bar reaches "100"%
	Then name of the button is changed to "Reset"
	When user clicks on Reset button
	Then name of the button is changed to "Start"
	Then value in the progress bar is 0%