Feature: Add_floors

Scenario Outline: [scenario name]
	Given user is logged in main page
	When user select "412d673d-d8ae-4f82-9e97-978b3b0cd2a7" bulding 
	And enter floor name <floorName>
	And enter floor number <floorNumber>
	And user save floor

Examples:
    | floorName | floorNumber |
    | 1         | 1           |
    | 2         | 2           |
    | 3         | 3           |
    | 4         | 4           |