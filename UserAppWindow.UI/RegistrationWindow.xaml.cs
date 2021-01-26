using SmartParkingApp;
using System.Windows;
using SmartParkingApp.Models;
using System.Text.RegularExpressions;

namespace UserAppWindow.UI
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        ParkingManager manager = new ParkingManager();
        
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private bool ConfirmPassword(string password_1, string password_2)
        {
            return password_1 == password_2;
        }
        private bool CheckPhoneFormat(string login)
        {
            string phoneFormat = @"\+7\d{10}";
            return Regex.IsMatch(login, phoneFormat);
        }

        private void Button_Registration(object sender, RoutedEventArgs e)
        {
            if (manager.CheckUser(textBoxPhone.Text) == null)
            {
                var user = new User{Name = textBoxName.Text};

                if (user.IsValid() && CheckPhoneFormat(textBoxPhone.Text) && ConfirmPassword(regPassword_1.Password, regPassword_2.Password))
                {
                    user.Phone = textBoxPhone.Text;
                    user.CarPlateNumber = textCarPlate.Text;
                    user.Password = regPassword_1.Password;
                    manager.AddUser(user);
                    MessageBox.Show("You have been successfully registered. Log in now.");
                    Close();
                }
                else
                    MessageBox.Show("Incorrect name, phone number format or passwords don't match. Try again.");
            }
            else
                MessageBox.Show("You've signed up earlier");
        }
         
        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
