using System.Collections.ObjectModel;

namespace ToDoApplication.Models
{
    public class TaskManager
    {
        //ObservableCollection to store the list of tasks
        public static ObservableCollection<Task> ListTasks = new ObservableCollection<Task>()
        {
            // Initial task examples to populate the main view
            new Task()
            {
                Title = "Unit 16",
                Description = "Create to do list",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = true,
                ToDelete = false,
            },
            new Task()
            {
                Title = "Unit 16",
                Description = "Create book sorting program",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = false,
                ToDelete = false,
            }
        };

        // Method to obtain the list of tasks
        public static ObservableCollection<Task> GetTasks()
        {
            return ListTasks;
        }

        // Method to add a new task to the list
        public static void AddTask(Task task)
        {
            ListTasks.Add(task);
        }

        // Method to delete a task from the list
        public static void DeleteTask(Task task)
        {
            ListTasks.Remove(task);
        }
    }
}
