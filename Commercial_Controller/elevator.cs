using System.Collections.Generic;
using System.Threading;
using System;
using System.Linq;

namespace Commercial_Controller
{
    public class Elevator
    {
        public string ID;
        public string status;
        public int amountOfFloors;
        public int currentFloor;
        public Door door;
        public List<int> floorRequestsList;
        public List<int> completedRequestsList;
        public string direction;
        public bool overweight;
        public bool obstruction;

        public Elevator(string _ID, string _status, int _amountOfFloors, int _currentFloor)
        {
            this.ID = _ID;
            this.status = _status;
            this.amountOfFloors = _amountOfFloors;
            this.currentFloor = _currentFloor;
            this.door = new Door(Convert.ToInt32(_ID), "closed");
            this.floorRequestsList = new List<int>();
            this.completedRequestsList = new List<int>();
            this.direction = "";
            this.overweight = false;
            this.obstruction = false;
        }

        public void move()
        {
            while (this.floorRequestsList.Count != 0)
	        {
                int destination = this.floorRequestsList[0];
                this.status = "moving";
                if (this.currentFloor < destination)
                {
                    this.direction = "Up";
                    sortFloorList();
                    while (this.currentFloor < destination)
                    {
                        this.currentFloor++;
                        // SET THIS screenDisplay TO THIS currentFloor
                    }
                }
                else if (this.currentFloor > destination)
                {
                    this.direction = "Down";
                    while (this.currentFloor > destination)
                    {
                        this.currentFloor--;
                        // SET THIS screenDisplay TO THIS currentFloor
                    }
                }
                this.status = "stopped";
                operateDoor();
                this.completedRequestsList.Add(this.floorRequestsList[0]);
                this.floorRequestsList.RemoveAt(0);
	        }
            this.status = "idle";
        }


        public void sortFloorList()
        {
            if (this.direction == "Up")
            {
                this.floorRequestsList.Sort((a, b)=> a.CompareTo(b));
            }
            else
            {
                this.floorRequestsList.Sort((a, b)=> b.CompareTo(a));
            }
        }

        public void operateDoor()
        {
            this.door.status = "opened";
            if (this.overweight != true)
            {
                this.door.status = "closing";
                if (this.obstruction != true)
                {
                    this.door.status = "closed";
                }
                else
                {
                    operateDoor();
                }
            }
            else
            {
                while (overweight)
                {
                    // activate overweight Alarm
                    this.overweight = false;
                }
                operateDoor();
            }
        }

        public void addNewRequest(int _requestedFloor)
        {
            if (this.floorRequestsList.Contains(_requestedFloor) != true)
            {
                this.floorRequestsList.Add(_requestedFloor);
            }

            if (this.currentFloor < _requestedFloor)
            {
                this.direction = "Up";
            }

            if (this.currentFloor > _requestedFloor)
            {
                this.direction = "Down";
            }
        }
    }
}


