Feature: Interactions

Background:
	When user open the Interactions category

Scenario: Selectable section
	Given user is on Selectable page
	When user goes to "grid" tab
	When user selects square "One"
	And user selects square "Three"
	And user selects square "Five"
	And user selects square "Seven"
	And user selects square "Nine"
	Then the values in selected squares are: "One", "Three", "Five", "Seven", "Nine"