Feature: Add_fixed_location

Scenario: [scenario name]
	Given user is logged in the admin panel
	When user goes to the page for creating fixed location
	And user enters "name" in the name field in Identity Information
	And select client name "nix"
	And select organization name "nix"
	And select floor "40c98fe3-eb5b-4fa2-a59e-1bd4b3d10b42"
	And enter Leaf Location
	And save the form
	And user create "5" fixed location for client "nix" org "nix" and floor "40c98fe3-eb5b-4fa2-a59e-1bd4b3d10b42"
