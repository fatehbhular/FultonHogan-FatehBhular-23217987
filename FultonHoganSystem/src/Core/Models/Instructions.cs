namespace Core.Models
{
    // This is a concrete class that represents a set of instructions sent to a site.
    // Instructions contains a list of tasks that have been rewritten by the Site Lead.
    public class Instructions
    {
        public string SenderID { get; set; }
        public string SiteID { get; set; }
        public List<string> ToDoList { get; set; }
        public DateTime Timestamp { get; set; }

        // Constructor that initialises a new set of instructions.
        // TodoList is initialised as an empty list of strings which are later filled with written instructions.
        public Instructions(string senderID, string siteID)
        {
            SenderID = senderID;
            SiteID = siteID;
            ToDoList = new List<string>();
            Timestamp = DateTime.Now;
        }

        // Returns the list of instructions
        public List<string> GetInstructions()
        {
            return ToDoList;
        }
    }
}