using System.Windows;
using System.Windows.Controls;

namespace CMCS
{
    public partial class CoordinatorManagerDashboard : Window
    {
        public CoordinatorManagerDashboard()
        {
            InitializeComponent();
            LoadClaims();
        }

        private void LoadClaims()
        {
            ClaimsListView.ItemsSource = ClaimsManager.Claims; // Access claims from the shared list
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var claim = button.DataContext as Claim; // Get the associated claim

            if (claim != null)
            {
                claim.Status = "Approved"; // Update status
                MessageBox.Show($"Claim {claim.ClaimID} approved!");
                LoadClaims(); // Refresh the ListView
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var claim = button.DataContext as Claim; // Get the associated claim

            if (claim != null)
            {
                claim.Status = "Rejected"; // Update status
                MessageBox.Show($"Claim {claim.ClaimID} rejected!");
                LoadClaims(); // Refresh the ListView
            }
        }
    }
}
