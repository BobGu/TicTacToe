﻿Feature: Player vs Player 
    In order to make sure
	A player vs player game of tic tac toe
	Is in the right order
	And the use sees the correct information

@mytag
Scenario: Player is asked for their name
	Given the game has started
	And game setup is already done
	And players have made the necessary moves
	Then I should have been asked for my name 

Scenario: Player is asked which marker they would like to be
    Given the game has started
	And game setup is already done
	And players have made the necessary moves
	Then I should have been asked what marker I would like to be

Scenario: Second player is asked for their name
    Given the game has started
	And game setup is already done
	And players have made the necessary moves
	Then the second player should have been asked for their name
	
Scenario: Players are asked who would like to move first
    Given the game has started
	And game setup is already done
	And players have made the necessary moves
	Then I expect to be asked about the turn order

Scenario: Player entering an invalid marker
    Given the game has started
	And I choose to play human vs human 
	And I have already entered my name
	And I enter a marker that is not X or O
	And I enter a valid marker
	And I enter a second players name
	And I enter a turn order
    And player enters board dimmensions 
	And players have made the necessary moves
	Then I am told my marker was invalid
	And I am asked again which marker I would like to be

Scenario: Player one chooses to go first
    Given the game has started
	And game setup is already done
	And player one chooses to go first
	And player enters board dimmensions
	And players have made the necessary moves
	Then I expect player one to be asked where they would like to move

Scenario: Player one chooses to go second
    Given the game has started
	And players have entered all their info
	And player one chooses to go second
	And player enters board dimmensions
	And players have made the necessary moves
	Then I expect player two to be asked where they would like to move

Scenario: Expect to see an empty board
    Given game setup is already done
	And players have made the necessary moves
	Then I expect the first board to be an empty board

Scenario: I can play a four by four game of tic tac toe
	Given the game has started
	And players have entered all their info
	And player one chooses to go second
	And I choose a four by four board
	And players have made the necessary moves
	Then I expect the first board to be an empty four by four board

Scenario: Player can mark a space
    Given game setup is already done
	And I choose the center space 
	And players have made the necessary moves
	Then I expect to see that space marked

Scenario: Second Player can mark a space
    Given game setup is already done
	And I choose the center space
	And second player chooses the top left space
	And players have filled the rest of the board 
	Then I expect to see the top left space filled with the correct marker

Scenario: First player wins
    Given game setup is already done
	And board is setup so player one can win
	And player one makes a winning move
	Then I expect to see a message congratualting player one

Scenario: Tie game
    Given game setup is already done
	And players move so that they are tied
	Then I expect to see a message saying the game is tied