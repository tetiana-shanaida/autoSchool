Feature: Add_floors

Scenario Outline: [scenario name]
	Given user is logged in main page
	When user select "43504e08-bd70-4e9c-b546-26376efe659d" bulding 
	And enter floor name <floorName>
	And enter floor number <floorNumber>
	And user save floor

Examples:
    | floorName | floorNumber |
    | 7         | 7           |
    | 8         | 8           |
    | 9         | 9           |
    | 10        | 10          |
    | 11        | 11          |
    | 12        | 12          |
    | 13        | 13          |