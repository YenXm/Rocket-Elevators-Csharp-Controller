using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        public static int columnID = 1;
        public static int elevatorID = 1;
        public static int floorRequestButtonID = 1;
        public static int callButtonID = 1;
        public static int floor;

        public int ID;
        public string status;
        public List<Column> columnsList;
        public List<FloorRequestButton> floorRequestsButtonsList;

        public Battery(
            int _ID,
            int _amountOfColumns,
            int _amountOfFloors,
            int _amountOfBasements,
            int _amountOfElevatorPerColumn
        )
        {
            this.ID = _ID;
            this.status = "idle"
            this.columnsList;
            this.floorRequestsButtonsList;

            if (_amountOfBasements > 0)
            {
                this.createBasementFloorRequestButtons(_amountOfBasements);
                this.createBasementColumn(_amountOfBasements, _amountOfElevatorPerColumn);
                _amountOfColumns--;
            }
            this.createFloorRequestButtons(_amountOfFloors);
            this.createColumns(_amountOfColumns, _amountOfFloors, _amountOfElevatorPerColumn);
        }

        public void createBasementColumn(
            int _amountOfBasements,
            int _amountOfElevatorPerColumn
        )
        {
            List<int> servedFloors = new List<int>();
            int floor = -1;
            for (int i = 0; i < _amountOfBasements; i++)
            {
                servedFloors.Add (floor);
                floor -= 1;
            }

            Column column =
                new Column(Convert.ToString(Battery.ColumnID),
                    "online",
                    _amountOfElevatorPerColumn,
                    servedFloors,
                    true);
            this.columnsList.Add(column);
            Battery.columnID++;
        }

        public void createColumns(int _amountOfColumns,
            int _amountOfFloors,
            int _amountOfElevatorPerColumn)

            
        {
            int amountOfFloorPerColumn = Math.Ceiling(_amountOfFloors / _amountOfColumns);
            int floor = 1;

            for (int i = 0; i < _amountOfColumns; i++)
            {
                List<int> servedFloors = new List<int>();
                for (int i = 0; i < amountOfFloorPerColumn; i++)
                {
                    if (floor =< _amountOfFloors)
                    {
                        servedFloors.Add(floor);
                        floor++;
                    }
                }
                Column column = new Column(Convert.ToString(Battery.columnID),
                    "online",
                    _amountOfFloors,
                    servedFloors,
                    false);
                this.columnsList.Add(column);
                Battery.columnID++;
            }
        }
        public void createFloorRequestButtons(int _amountOfFloors)
        {
            int buttonFloor = 1;
            for (int i = 0; i < _amountOfFloors; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton(
                    Battery.floorRequestButtonID,
                    "Off",
                    buttonFloor,
                    "Up");
                this.floorRequestsButtonsList.Add(floorRequestButton);
                buttonFloor++;
                Battery.floorRequestButtonID++;
            }
        }
        public void createBasementFloorRequestButtons(int _amountOfBasements)
        {
            int buttonFloor = -1;
            for (int i = 0; i < _amountOfBasements; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton(
                    Battery.floorRequestButtonID,
                    "Off",
                    buttonFloor,
                    "Down");
                this.floorRequestsButtonsList.Add(floorRequestButton);
                buttonFloor--;
                Battery.floorRequestButtonID++;
            }
        }
        public Column findBestColumn(int _requestedFloor)
        {
            foreach (Column column in this.columnsList)
            {
                if (column.servedFloorsList.Contains(_requestedFloor)
                {
                    return column
                }
            }
        }

        public void assignElevator(int _requestFloor, string _direction)
        {
            Column column = findBestColumn(_requestFloor);
            Elevator elevator = column.findElevator(1, _direction);
            elevator.AddNewRequest(1);
            elevator.move();
            elevator.addNewRequest(_requestFloor);
            elevator.move();
        }
    }
}
