using System.Threading;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        public Elevator(string _elevatorID)
        {
            string ID = _elevatorID;
            string status = "idle";
            int currentFloor = 1;
            string direction = 'null'
            Door door = new Door();
            List<int> floorRequestsList = new List<int>();
            List<int> completedRequestsList = new List<int>();
        }
        public void move()
        {

        }
        
    }
}