using System.Collections.Generic;
using System.Linq;
using SmartParkingApp.Models;

namespace SmartParkingApp
{
    
    public abstract class ClassForGetingSessionsLists : ParkingManager
    {
        public abstract ParkingSession ActiveSessionForUser(User user, List<ParkingSession> parkingSessions);
        public abstract List<ParkingSession> GetSessionsList(User user, List<ParkingSession> list);

    }
    // class for using data lists from ParkingManager like sessions and users
    public class ListRepository : ClassForGetingSessionsLists
    {
        public override ParkingSession ActiveSessionForUser(User user, List<ParkingSession> parkingSessions)
        {
            return parkingSessions.FirstOrDefault(s => s.UserId == user.Id);
        }
        public override List<ParkingSession> GetSessionsList(User user, List<ParkingSession> list)
        {
            if (user == null)
                return list;
            else
            {
                List<ParkingSession> nullList = new List<ParkingSession>();
                nullList.Add(list.FirstOrDefault(s => s.UserId == user.Id));
                return list.Where(s => s.User == user).ToList() ?? nullList;
            }
        }
    }
}
