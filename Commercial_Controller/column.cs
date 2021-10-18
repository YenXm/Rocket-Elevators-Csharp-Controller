using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    {
        public Column(
            string _ID,
            int _amountOfElevators,
            List<int> _servedFloors,
            bool _isBasement
        )
        {
            string ID = _ID;
            string status = "off";
            int amountOfElevators = _amountOfElevators;
            List<int> servedFloors = _servedFloors;
            bool isBasement = _isBasement;
            List<Elevator> elevatorsList = new List<Elevator>();
            List<CallButton> callButtonsList = new List<CallButton>();
        }

        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int userPosition, string direction)
        {
        }
    }
}
