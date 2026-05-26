namespace Core.Models
{
    // This is a concrete class that represents a timesheet belonging to an employee.
    // A Timesheet contains many entries added by a Heavy Machine Operator or General Labouer.
    public class Timesheet
    {
        public string TimesheetID { get; set; }
        public string OwnerID { get; set; }
        public List<Entry> Entries { get; set; }
        public DateOnly PayPeriod { get; set; }


        // Constructor that initialises a new timesheet.
        // A new instance is created when there is no available entry in the database.
        public Timesheet(string timesheetID, string ownerID, DateOnly payPeriod)
        {
            TimesheetID = timesheetID;
            OwnerID = ownerID;
            PayPeriod = payPeriod;
            Entries = new List<Entry>();
        }

        // Adds a new entry into this timesheet
        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }

        // Removes an existing entry from this timesheet
        public void RemoveEntry(Entry entry)
        {
            Entries.Remove(entry);
        }

        // Calculates and returns a summary of pay for this timesheet.
        public string GetPaySummary(string timesheetID)
        {
            // TODO: Do the logic of the calculation.
            return string.Empty;
        }
    }
}