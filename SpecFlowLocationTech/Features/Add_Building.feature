Feature: Add_Building

Scenario: Add building
	Given user is logged in
	When user go to add building page
	And adds new "office" building to "nix" organization
