# TicTacToe in C Sharp #

Hello.  To run this version of Tic Tac Toe you need windows, which should have .NET already installed.

Next you want to take the `bin/TicTacToe.exe` file and run that in your command line.  

## Features ##

* You can play human vs human or computer vs computer
* You can play an easy computer or hard computer which never loses
* Computer makes use of the minmax algorithim

### Tests ###
The tests were written using NUnit, you are going to need the NUnit console runner.  You can download the package through your NUGet package
manager if you are using Visual Studio or there are instructions here https://www.nuget.org/packages/NUnit.Runners/.

Once you have NUnit, once you are in the folder `TicTacToe.Tests', 
run your runner in the command line with the file name `TicTacToeTest.csproj`
This includes both unit tests, and feature test using SpecFlow

There is a separate test that takes a while to run in the GenerativeTest folder.  It proves the computer in unbeatable to run that test 
navigate to the `GeneartiveTest` folder and use your NUnit console runner with the file name `ComputerIsUnbeatableTest.csproj`
