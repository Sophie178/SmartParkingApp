using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParkingApp;
using SmartParkingApp.Models;

namespace SmartParkingApp
{
    public class PercentageSpaces
    {
        public double Value = 0;

        public double GetPercent(List<ParkingSession> parkingSessions, int capacity)
        {
            return Value = capacity * parkingSessions.Count * 0.01;
        }
    }
}
