using Microsoft.Win32;
using System;
using System.Windows;

namespace CMCS
{
    public partial class ClaimSubmission : Window
    {
        public event Action<Claim> ClaimSubmitted;
        private string uploadedFilePath;
        private string lecturerID; // Declare lecturerID

        public ClaimSubmission(string lecturerID)
        {
            InitializeComponent();
            this.lecturerID = lecturerID; // Initialize lecturerID
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Document Files|*.docx;*.xlsx;*.pdf|All Files|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                uploadedFilePath = openFileDialog.FileName;
                UploadedFileName.Text = System.IO.Path.GetFileName(uploadedFilePath);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(HoursWorkedTextBox.Text) || string.IsNullOrWhiteSpace(HourlyRateTextBox.Text))
                {
                    MessageBox.Show("Please enter both hours worked and hourly rate.");
                    return;
                }

                if (!double.TryParse(HoursWorkedTextBox.Text, out double hoursWorked) ||
                    !double.TryParse(HourlyRateTextBox.Text, out double hourlyRate))
                {
                    MessageBox.Show("Please enter valid numeric values for hours worked and hourly rate.");
                    return;
                }

                Claim newClaim = new Claim
                {
                    ClaimID = null, // Set ClaimID to null
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    Status = "Pending",
                    HoursWorked = hoursWorked,
                    HourlyRate = hourlyRate,
                    Notes = NotesTextBox.Text,
                    DocumentPath = uploadedFilePath,
                    LecturerID = lecturerID // Use the lecturerID here
                };

                ClaimsManager.Claims.Add(newClaim); // Add claim to the shared list
                ClaimSubmitted?.Invoke(newClaim);
                MessageBox.Show("Claim submitted successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
