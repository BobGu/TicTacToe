Feature: Player Vs Player 
  As a user playing tic tac toe
  I expect all the scenarios of this type of game
  To work correctly

@mytag
Scenario: First player is asked for their name 
	Given I have started the game
	Then  I should be asked for my name

Scenario: First player is asked which piece they would like to be
    Given I have started the game
	And I have entered my name correctly
	Then I should be asked which piece I would like to be

Scenario: First player is asked for piece again when entered incorrectly
    Given I have started the game
	And I have entered my name correctly
	When I enter piece that isn't correct
	Then I should be asked again which piece I would like to be

