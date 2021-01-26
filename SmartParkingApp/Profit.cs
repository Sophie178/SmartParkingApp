using System;
using System.Collections.Generic;
using System.Linq;
using SmartParkingApp.Models;

namespace SmartParkingApp
{
    // class for calculating profit for period
    public class Profit
    {
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public decimal value;
        public void GetProfit()
        {
            ListRepository repository = new ListRepository();
            value = 0;
            repository.AppData();

            List<ParkingSession> sessions = repository.CompletedSessions.Where(s => (StartDate != null && FinishDate != null)?
            (s.EntryDt >= StartDate && s.ExitDt <= FinishDate) : (StartDate == null ? s.ExitDt <= FinishDate: s.EntryDt >= StartDate)).ToList();

            value = sessions.Sum(s => s.TotalPayment ?? 0);
        }
    }
}
