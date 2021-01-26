using System;

namespace SmartParkingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Smart parking application");

            var manager = new ParkingManager();
            
            // to use GUI for user or owner set required project as a StartUp project

            Console.ReadKey();
        }
    }
}
