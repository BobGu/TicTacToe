Feature: Player vs Player 
    In order to make sure
	A player vs player game of tic tac toe
	Is in the right order
	And the use sees the correct information

@mytag
Scenario: Player is asked for their name
	Given the game has started
	Then I should be asked for my name 

Scenario: Player is asked which piece they would like to be
    Given the game has started
	And I have already entered my name
	Then I expect to be asked what piece I would like to be