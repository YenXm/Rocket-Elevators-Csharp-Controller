# Rocket-Elevators-Csharp-Controller
This program use OOP to create its structure.  
                                       Battery -> Columns, Floor Requests Buttons
                                           ///Column -> Elevators, Call Requests buttons
                                               ///Elevator -> Door

A scenario work by initializing a battery then, for the column it will test, it will manually change the current floor, floor requests list, direction and status of its elevator to simulate a set of elevator already working. After that, it will then launch a new request to the battery and expect the battery to pass it to the previously mentionned column and the column to pass it to the right elevator based on its algorithm. In the end it will then activate all the elevator and wait for the return of the chosen elevator and the chosen column to send to the tester.

The tester will then evaluate the state (not the attribute status) of the column and assert that all its elevator are where they should be if the algorithm was working properly.



### Installation

As long as you have **.NET 5.0** installed on your computer, nothing more needs to be installed:

The code to run the scenarios is included in the Commercial_Controller folder, and can be executed there with:

`dotnet run <SCENARIO-NUMBER>`

### Running the tests

To launch the tests, make sure to be at the root of the repository and run:

`dotnet test`

With a fully completed project, you should get an output like:

![Screenshot from 2021-06-15 17-31-02](https://user-images.githubusercontent.com/28630658/122128889-3edfa500-ce03-11eb-97d0-df0cc6a79fed.png)

You can also get more details about each test by adding the `-v n` flag: 

`dotnet test -v n` 

which should give something like: 

![Screenshot from 2021-06-15 18-00-52](https://user-images.githubusercontent.com/28630658/122129140-a8f84a00-ce03-11eb-8807-33d7eab8c387.png)

