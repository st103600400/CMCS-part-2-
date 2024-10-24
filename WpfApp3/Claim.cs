public class Claim
{
    public string ClaimID { get; set; }
    public string Date { get; set; }
    public string Status { get; set; }
    public double HoursWorked { get; set; }
    public double HourlyRate { get; set; }
    public string Notes { get; set; }
    public string DocumentPath { get; set; }
    public string LecturerID { get; set; } // Associate claim with lecturer
}
