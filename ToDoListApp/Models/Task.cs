namespace ToDoApplication.Models
{
    public class Task
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; } // Status of the task (completed, incomplete)
        public bool ToDelete { get; set; } //Flag indicating if task should be deleted

        // Override ToString method to prove string representation of the task
        public override string ToString() => $"{Title} {Description} {StartDate:d} {EndDate:d} {(Status ? "Completed" : "Incomplete")}";

        public Task()
        {

        }
    }
}
