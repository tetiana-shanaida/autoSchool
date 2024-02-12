Feature: Add_fixed_location

Scenario: [scenario name]
	Given user is logged in the admin panel
	When user goes to the page for creating fixed location
	And user enters "name" in the name field in Identity Information
	And select client name "nix"
	And select organization name "nix"
	And select floor "e7fd51a4-6a68-44f0-a528-5cf57f84b125"
	And enter Leaf Location "bath"
	And save the form
