@f2
Feature: Addition
	In order to make my library grow
	As a registered user
	I want to add movies to the library

	Scenario: Add a movie
		Given I have no movies
		And   I am on "home"
		When  I follow "create" 
		And   I fill in "movie_title" with "Young Frankenstein"
		And   I press "Submit"
		Then  I should see "Young Frankenstein"
