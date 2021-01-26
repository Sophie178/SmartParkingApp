using SmartParkingApp;
using System.Windows;

namespace UserAppWindow.UI
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        ListRepository repository = new ListRepository();
        public AuthorizationWindow()
        {
            InitializeComponent();
            repository.AppData();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            var user = repository.Authorize(textboxLogin.Text, passwordBox.Password);
            if (user != null)
            {
                Close();
                var sessionsWindow = new SessionsWindow(user, repository);
                sessionsWindow.ShowDialog();
                
            }
            else
                MessageBox.Show("Please try again.");
        }
    }
}
