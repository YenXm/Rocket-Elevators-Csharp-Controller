using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    {
        public int ID;
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
            this.elevatorsList;
            this.callButtonsList;
        }

        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int userPosition, string direction)
        {
        }

        public void createCallButton(int _amountOfFloors, bool _isBasement)
        {
            if (_isBasement)
            {
                int buttonFloor = -1;
                for (int i = 0; i < _amountOfFloors; i++)
			    {
                    CallButton callbutton = new CallButton(
                        Battery.callButtonID,
                        "Off",
                        buttonFloor,
                        "Up");
                    this.callButtonsList.Add(callbutton);
                    buttonFloor--;
                    Battery.callButtonID++;
			    }
            }
            else
            {
                int buttonFloor = 1;
                for (int i = 0; i < _amountOfFloors; i++)
			    {
                    CallButton callbutton = new CallButton(
                        Battery.callButtonID,
                        "Off",
                        buttonFloor,
                        "Down");
                    this.callButtonsList.Add(callbutton);
                    buttonFloor++;
                    Battery.callButtonID++;
			    }
            }
        }

        public void createElevators(int _amountOfFloors, int _amountOfElevators)
        {
            for (int i = 0; i < _amountOfElevators; i++)
			{
                Elevator elevator = new Elevator
			}
        }
    }
}


//    SEQUENCE createElevators USING _amountOfFloors AND _amountOfElevators 
//        FOR _amountOfElevators
//            SET elevator TO NEW Elevator WITH elevatorID AND idle AND _amountOfFloors AND 1
//            ADD elevator TO THIS elevatorsList
//            INCREMENT elevatorID
//        ENDFOR
//    ENDSEQUENCE
//    '//Simulate when a user press a button on a floor to go back to the first floor
//    SEQUENCE requestElevator USING userPosition AND direction
//        SET elevator TO CALL THIS findElevator WITH userPosition AND direction RETURNING elevator
//        CALL elevator addNewRequest WITH _requestedFloor
//        CALL elevator move
//        CALL elevator addNewRequest WITH 1 '//Always 1 because the user can only go back to the lobby
//        CALL elevator move
//    ENDSEQUENCE