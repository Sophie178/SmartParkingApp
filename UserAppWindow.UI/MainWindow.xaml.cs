using System.Windows;
using SmartParkingApp;

namespace UserAppWindow.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListRepository repository = new ListRepository();
        public MainWindow()
        {
            InitializeComponent();
            repository.AppData();
        }

        private void Registration_Button(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegistrationWindow();
            registerWindow.ShowDialog();
        }

        private void Authorization_Button(object sender, RoutedEventArgs e)
        {
            var authorizeWindow = new AuthorizationWindow();
            authorizeWindow.ShowDialog();
        }
    }
}
