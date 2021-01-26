using System.Windows;
using System.Windows.Controls;
using SmartParkingApp;

namespace OwnerAppWindow.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListRepository repository = new ListRepository();
        Profit profit = new Profit();
        public MainWindow()
        {
            InitializeComponent();
            repository.AppData();

            allPastSessions.ItemsSource = repository.GetSessionsList(null, repository.CompletedSessions);
            filledSpaces.Text = $"Percent of filled spaces: {repository.GetPercent()} %";
            allCurrentSessions.ItemsSource = repository.GetSessionsList(null, repository.ActiveSessions);
            
        }

        private void FirstDateSelected(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            profit.StartDate = picker.SelectedDate;
            profit.GetProfit();
            profitValue.Text = $"Profit: {profit.value}";
        }

        private void SecondDateSelected(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            profit.FinishDate = picker.SelectedDate;
            profit.GetProfit();
            profitValue.Text = $"Profit: {profit.value}";
        }
    }
}
