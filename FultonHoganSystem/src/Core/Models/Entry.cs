namespace Core.Models
{
    // This is a concrete class that represents a single entry in a timesheet.
    // Each entry records the hours worked on a specific date by a certain employee.
    public class Entry
    {
        public string TimesheetID { get; set; }
        public string OwnerID { get; set; }
        public DateOnly DateWorked { get; set; }
        public TimeOnly TimeWorked { get; set; }

        // Constructor that initialises a new entry instance.
        // Called on initialisation of an entry.
        // This method creates a timesheet entry.
        public Entry(string timesheetID, string ownerID, DateOnly dateWorked, TimeOnly timeWorked)
        {
            TimesheetID = timesheetID;
            OwnerID = ownerID;
            DateWorked = dateWorked;
            TimeWorked = timeWorked;
        }

        // Returns this entry instance
        // This method returns this entry.
        public Entry GetEntry()
        {
            return this;
        }
    }
}
