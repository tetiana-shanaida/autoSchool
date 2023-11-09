Feature: AlertFrameWindows

Background:
	Given user is on the main page
	When user goes to the Alerts, Frame & Windows category

Scenario Outline:: Browser Windows
	Given user is on Browser Windows page
	When user opens <buttonName>
	And user goes to new tab or window
	Then user see text "This is a sample page" on the page

Examples:
    | buttonName   |
    | tabButton    |
    | windowButton |