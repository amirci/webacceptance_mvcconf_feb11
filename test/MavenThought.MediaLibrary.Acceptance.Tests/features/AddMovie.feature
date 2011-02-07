@wip
Feature: Addition
	In order to make my library grow
	As a registered user
	I want to add movies to the library

	Scenario: Add a movie
		Given I'm on the "home" page
		When  I follow "Add Media" 
		And   I enter "Young Frankenstein" in the title
		And   I click Submit
		Then  I should see "Young Frankenstein" in the listing
