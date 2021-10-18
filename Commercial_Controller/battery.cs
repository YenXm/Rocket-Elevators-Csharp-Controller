using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        public Battery(
            int _ID,
            int _amountOfColumns,
            int _amountOfFloors,
            int _amountOfBasements,
            int _amountOfElevatorPerColumn
        )
        {
            int ID = _ID;
            string status = "off";
            List<Column> columnsList = new List<Column>();
            List<FloorRequestButton> floorRequestButtonsList =
                new List<FloorRequestButton>();
        }

        public Column findBestColumn(int _requestedFloor)
        {
        }

        //Simulate when a user press a button at the lobby
        public (Column, Elevator)
        assignElevator(int _requestedFloor, string _direction)
        {
        }
    }
}
