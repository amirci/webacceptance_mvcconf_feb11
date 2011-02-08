@f1
Feature: Browse Movies
	As a User
	I want to Browse Movies
	So I can see the contents of the library
	
	Scenario: Browse available movies
		Given I have the following movies:
			| title           | 
			| Blazing Saddles | 
			| Space Balls     |
		When I go to "Movies"
		Then I should see "Blazing Saddles"
		And  I should see "Space Balls"

	Scenario: Browse empty library
		Given I have no movies
		When  I go to "home"
		Then  I should see "Sorry no movies available!"
				