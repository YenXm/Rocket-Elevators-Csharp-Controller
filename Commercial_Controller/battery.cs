using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        private int columnID = 1;
        private int floorRequestButtonID = 1;


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
            this.status = "idle";
            this.columnsList = new List<Column>();
            this.floorRequestsButtonsList = new List<FloorRequestButton>();

            if (_amountOfBasements > 0)
            {
                createBasementFloorRequestButtons(_amountOfBasements);
                createBasementColumn(_amountOfBasements, _amountOfElevatorPerColumn);
                _amountOfColumns--;
            }
            createFloorRequestButtons(_amountOfFloors);
            createColumns(_amountOfColumns, _amountOfFloors, _amountOfElevatorPerColumn);
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
                new Column(Convert.ToString(columnID),
                    "online",
                    _amountOfBasements,
                    _amountOfElevatorPerColumn,
                    servedFloors,
                    true);
            this.columnsList.Add(column);
            columnID++;
            Console.WriteLine(column.ID);
        }

        public void createColumns(int _amountOfColumns,
            int _amountOfFloors,
            int _amountOfElevatorPerColumn)

            
        {
            int amountOfFloorPerColumn = (int) Math.Ceiling(Convert.ToDouble(_amountOfFloors) / Convert.ToDouble(_amountOfColumns));
            int floor = 1;

            for (int i = 0; i < _amountOfColumns; i++)
            {
                List<int> servedFloors = new List<int>();
                for (int y = 0; y < amountOfFloorPerColumn; y++)
                {
                    if (floor <= _amountOfFloors)
                    {
                        servedFloors.Add(floor);
                        
                        floor++;
                    }
                }
                Column column = new Column(Convert.ToString(columnID),
                    "online",
                    _amountOfFloors,
                    _amountOfElevatorPerColumn,
                    servedFloors,
                    false);
                this.columnsList.Add(column);
                columnID++;
                Console.WriteLine(column.ID);
            }
        }
        public void createFloorRequestButtons(int _amountOfFloors)
        {
            int buttonFloor = 1;
            for (int i = 0; i < _amountOfFloors; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton(
                    floorRequestButtonID,
                    "Off",
                    buttonFloor,
                    "Up");
                this.floorRequestsButtonsList.Add(floorRequestButton);
                buttonFloor++;
                floorRequestButtonID++;
            }
        }
        public void createBasementFloorRequestButtons(int _amountOfBasements)
        {
            int buttonFloor = -1;
            for (int i = 0; i < _amountOfBasements; i++)
            {
                FloorRequestButton floorRequestButton = new FloorRequestButton(
                    floorRequestButtonID,
                    "Off",
                    buttonFloor,
                    "Down");
                this.floorRequestsButtonsList.Add(floorRequestButton);
                buttonFloor--;
                floorRequestButtonID++;
            }
        }
        public Column findBestColumn(int _requestedFloor)
        {
            foreach (Column column in this.columnsList)
            {
                if (column.servedFloorsList.Contains(_requestedFloor))
                {
                    return column;
                }
            }
            Console.WriteLine("wrong place");
            return this.columnsList[0];
        }

        public (Column, Elevator) assignElevator(int _requestFloor, string _direction)
        {
            Column column = findBestColumn(_requestFloor);
            Elevator elevator = column.findElevator(1, _direction);
            elevator.addNewRequest(1);
            elevator.move();
            elevator.addNewRequest(_requestFloor);
            elevator.move();
            return (column, elevator);
        }
    }
}
