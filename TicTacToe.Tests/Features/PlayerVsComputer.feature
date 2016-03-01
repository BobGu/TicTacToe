Feature: Player Vs Computer
  In order to see if a human can play vs a computer player

@mytag
Scenario: Player chooses and human vs computer game 
    Given the game has already started
	And I choose a human vs computer game    
	And the first player entered all their info
	And player one chooses to go last
	And all other info is entered for the game
	Then I expect the computer player to be asked for their name
	
