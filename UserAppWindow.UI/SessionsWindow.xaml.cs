using SmartParkingApp.Models;
using System.Collections.Generic;
using System.Windows;
using SmartParkingApp;

namespace UserAppWindow.UI
{
    /// <summary>
    /// Interaction logic for SessionsWindow.xaml
    /// </summary>
    public partial class SessionsWindow : Window
    {
        User authorizedUser;
        public SessionsWindow(User user, ListRepository listRepository)
        {
            InitializeComponent();
            authorizedUser = user;
            listRepository.AppData();

            ParkingSession activeSession = listRepository.ActiveSessionForUser(authorizedUser, listRepository.ActiveSessions);
            if (activeSession != null)
            {
                List<ParkingSession> activeSessions = new List<ParkingSession>();
                activeSessions.Add(activeSession);
                currentSessionData.ItemsSource = activeSessions;

            }
            completedSessionsData.ItemsSource = listRepository.GetSessionsList(authorizedUser, listRepository.CompletedSessions);
            tariffData.ItemsSource = listRepository.GetTariffs();
        }
    }
}
