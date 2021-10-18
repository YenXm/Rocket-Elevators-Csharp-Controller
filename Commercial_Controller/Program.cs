using System;

namespace Commercial_Controller
{
    class Program
    {
        /*          static void Main(string[] args)
        {
            int scenarioNumber = Int32.Parse(args[0]);
            Scenarios scenarios = new Scenarios();
            scenarios.run(scenarioNumber);
        }  */
        static void Main(string[] args)
        {
            Battery test = new Battery(1, 2, 10, 5, 2);
        }
    }
}
