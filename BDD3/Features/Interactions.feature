Feature: Interactions

A short summary of the feature

@tag1
Scenario: Selectable section
	Given user is on Selectable page
	When user goes to "grid" tab
	When user selects square "One"
	And user selects square "Three"
	And user selects square "Five"
	And user selects square "Seven"
	And user selects square "Nine"
	Then the value of "1" selected square is "One"
	And the value of "2" selected square is "Three"
	And the value of "3" selected square is "One"
	And the value of "4" selected square is "One"
	And the value of "5" selected square is "One"