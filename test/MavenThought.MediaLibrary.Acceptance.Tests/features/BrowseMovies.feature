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
		Then I should see in the listing:
		  | title             |
		  | Blazing Saddles   |
		  | Space Balls       |

	Scenario: Browse empty library
		Given I have no movies
		When  I go to "Movies"
		Then  I should see the message "Sorry no movies available!"
		