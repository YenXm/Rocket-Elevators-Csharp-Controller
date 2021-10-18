using System.Collections.Generic;
using System.Threading;

namespace Commercial_Controller
{
    public class Elevator
    {
        public Elevator(string _elevatorID)
        {
            string ID = _elevatorID;
            string status = "idle";
            int currentFloor = 1;
            string direction = "";
            Door door = new Door(_elevatorID);
            List<int> floorRequestsList = new List<int>();
            List<int> completedRequestsList = new List<int>();
        }

        public void move()
        {
        }
    }
}
