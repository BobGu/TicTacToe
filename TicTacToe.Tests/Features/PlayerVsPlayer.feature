﻿Feature: Player vs Player 
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

Scenario: Second player is asked for their name
    Given the game has started
	And the first player has entered their info
	Then the second player should be asked for their name
	
Scenario: Players are asked who would like to move first
    Given the game has started
	And players have entered all their info
	Then I expect to be asked about the turn order

Scenario: Player one chooses to go first
    Given the game has started
	And players have entered all their info
	And player one chooses to go first
	Then I expect player one to be asked where they would like to move

Scenario: Player one chooses to go second
    Given the game has started
	And players have entered all their info
	And player one chooses to go second
	Then I expect player two to be asked where they would like to move


