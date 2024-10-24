using System.Windows;

namespace CMCS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Assume the lecturer ID is the username for this example
            string lecturerID = UsernameTextBox.Text;

            if (LecturerRadioButton.IsChecked == true)
            {
                LecturerDashboard lecturerDashboard = new LecturerDashboard(lecturerID);
                lecturerDashboard.Show();
                this.Close();
            }
            else if (CoordinatorRadioButton.IsChecked == true || ManagerRadioButton.IsChecked == true)
            {
                // Navigate to Coordinator/Manager Dashboard
                CoordinatorManagerDashboard coordinatorManagerDashboard = new CoordinatorManagerDashboard();
                coordinatorManagerDashboard.Show();
                this.Close();
            }
        }
    }
}
