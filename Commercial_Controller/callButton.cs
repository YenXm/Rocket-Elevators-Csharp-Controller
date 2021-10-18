namespace Commercial_Controller
{
    //Button on a floor or basement to go back to lobby
    public class CallButton
    {
        public CallButton(int _ID, int _floor, string _direction)
        {
            int ID = _ID;
            string status = "off";
            int floor = _floor;
            string direction = _direction;
        }
    }
}
