using System.Windows.Input;
using ToDoApplication.Commands;
using ToDoApplication.Models;
using Task = ToDoApplication.Models.Task;

namespace ToDoApplication.ViewModels
{
    public class CreateTaskViewModel
    {
        public ICommand AddTaskCommand { get; set; } // Command to add a task
        // Task properties
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public bool ToDelete { get; set; }

        // Constructor to initialise commands
        public CreateTaskViewModel()
        {
            AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
        }

        // Method to determine if task can be added (always true here)
        private bool CanAddTask(object obj)
        {
            return true;
        }

        // Method to add the task to the task manager
        private void AddTask(object obj)
        {
            TaskManager.AddTask(new Task()
            {
                Title = Title,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                Status = false,
                ToDelete = false,
    });
        }
    }
}
