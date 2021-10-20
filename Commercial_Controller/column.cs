using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    {

        private int callButtonID = 1;
        private int elevatorID = 1;

        public string ID;
        public string status;
        public int amountOfFloors;
        public int amountfOfElevators;
        public List<Elevator> elevatorsList;
        public List<CallButton> callButtonsList;
        public List<int> servedFloorsList;
        public bool isBasement;

        public Column(
            string _ID,
            string _status,
            int _amountOfFloors,
            int _amountOfElevators,
            List<int> _servedFloors,
            bool _isBasement
        )
        {
            this.ID = _ID;
            this.status = _status;
            this.amountfOfElevators = _amountOfElevators;
            this.servedFloorsList = _servedFloors;
            this.isBasement = _isBasement;
            this.elevatorsList = new List<Elevator>();
            this.callButtonsList = new List<CallButton>();
            this.servedFloorsList = _servedFloors;

            createElevators(_amountOfFloors, _amountOfElevators);
            createCallButton(_amountOfFloors, _isBasement);
        }

        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int userPosition, string direction)
        {
            Elevator elevator = findElevator(userPosition, direction);
            elevator.addNewRequest(userPosition);
            elevator.move();

            elevator.addNewRequest(1);
            elevator.move();
            return elevator;
        }



        public void createCallButton(int _amountOfFloors, bool _isBasement)
        {
            if (_isBasement)
            {
                int buttonFloor = -1;
                for (int i = 0; i < _amountOfFloors; i++)
			    {
                    CallButton callbutton = new CallButton(
                        callButtonID,
                        "Off",
                        buttonFloor,
                        "up");
                    this.callButtonsList.Add(callbutton);
                    buttonFloor--;
                    callButtonID++;
			    }
            }
            else
            {
                int buttonFloor = 1;
                for (int i = 0; i < _amountOfFloors; i++)
			    {
                    CallButton callbutton = new CallButton(
                        callButtonID,
                        "Off",
                        buttonFloor,
                        "down");
                    this.callButtonsList.Add(callbutton);
                    buttonFloor++;
                    callButtonID++;
			    }
            }
        }

        public void createElevators(int _amountOfFloors, int _amountOfElevators)
        {
            for (int i = 0; i < _amountOfElevators; i++)
			{
                Elevator elevator = new Elevator(
                    Convert.ToString(elevatorID),
                    "idle",
                    _amountOfFloors,
                    1);
                this.elevatorsList.Add(elevator);
                elevatorID++;

			}
        }

        public (Elevator, int, int) checkIfElevatorIsBetter(
            int scoreToCheck,
            Elevator newElevator,
            int bestScore,
            int referenceGap,
            Elevator bestElevator,
            int floor)
        {
            if (scoreToCheck < bestScore)
            {
                bestScore = scoreToCheck;
                bestElevator = newElevator;
                referenceGap = Math.Abs(newElevator.currentFloor - floor);
            }
            else if (bestScore == scoreToCheck)
            {
                int gap = Math.Abs(newElevator.currentFloor - floor);
                if (referenceGap > gap)
                {
                    bestElevator = newElevator;
                    referenceGap = gap;
                }
            }
            return (bestElevator, bestScore, referenceGap);
        }
        
        public Elevator findElevator(int requestedFloor, string requestedDirection)
        {
            Elevator bestElevator = null;
            int bestScore = 6;
            int referenceGap = 1000000;
            (Elevator bestElevator, int bestScore, int referenceGap) bestElevatorInformations;

            if (requestedFloor == 1)
            {
                foreach (Elevator elevator in this.elevatorsList)
                {
                    if (elevator.currentFloor == 1 && elevator.status == "stopped")
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            1,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    else if (elevator.currentFloor == 1 && elevator.status == "idle")
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            2,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    else if (elevator.currentFloor < 1 && elevator.direction == "up")
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            3,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    else if (elevator.currentFloor > 1 && elevator.direction == "down")
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            3,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    else if (elevator.status == "idle")
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            4,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    else
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            5,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    bestElevator = bestElevatorInformations.bestElevator;
                    bestScore = bestElevatorInformations.bestScore;
                    referenceGap = bestElevatorInformations.referenceGap;
	            }
            }
            else
            {
                foreach (Elevator elevator in this.elevatorsList)
                {
                    if (requestedFloor == elevator.currentFloor && elevator.status == "stopped" && requestedDirection == elevator.direction)
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            1,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }

                    else if (requestedFloor > elevator.currentFloor && elevator.direction == "up" &&  requestedDirection == "up")
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            2,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    else if (requestedFloor < elevator.currentFloor && elevator.direction == "down" && requestedDirection == "down")
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            2,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    else if (elevator.status == "idle")
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            4,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    else
                    {
                        bestElevatorInformations = checkIfElevatorIsBetter(
                            5,
                            elevator,
                            bestScore,
                            referenceGap,
                            bestElevator,
                            requestedFloor);
                    }
                    bestElevator = bestElevatorInformations.bestElevator;
                    bestScore = bestElevatorInformations.bestScore;
                    referenceGap = bestElevatorInformations.referenceGap;
                }
            }
            return bestElevator;
        }
    }
}





