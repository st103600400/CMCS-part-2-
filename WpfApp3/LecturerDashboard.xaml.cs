using System.Linq;
using System.Windows;

namespace CMCS
{
    public partial class LecturerDashboard : Window
    {
        private string currentLecturerID;

        public LecturerDashboard(string lecturerID)
        {
            InitializeComponent();
            currentLecturerID = lecturerID;
            LoadClaims();
        }

        private void LoadClaims()
        {
            var filteredClaims = ClaimsManager.Claims
                .Where(c => c.LecturerID == currentLecturerID).ToList();

            ClaimsListView.ItemsSource = filteredClaims;
        }

        private void SubmitClaimButton_Click(object sender, RoutedEventArgs e)
        {
            ClaimSubmission claimSubmission = new ClaimSubmission(currentLecturerID);
            claimSubmission.ClaimSubmitted += (newClaim) => LoadClaims();
            claimSubmission.ShowDialog();
        }

        private void CheckStatusButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Check Claim Status button clicked!");
        }

        private void BackToMainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
