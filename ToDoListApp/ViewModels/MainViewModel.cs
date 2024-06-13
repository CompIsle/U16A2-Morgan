using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using ToDoApplication.Commands;
using ToDoApplication.Models;
using ToDoApplication.Views;
using Task = ToDoApplication.Models.Task;

namespace ToDoApplication.ViewModels
{
    public class MainViewModel
    {
        // Collection of tasks 
        public ObservableCollection<Task> Tasks { get; set; }
        // Command to show a new window (create task view)
        public ICommand ShowWindowCommand { get; set; }
        // Command to dump tasks to the debug output
        public ICommand DumpTasksCommand { get; set; }
        // Command to delete tasks
        public ICommand DeleteTaskCommand { get; set; }

        // Constructor to initialise commands and task collection
        public MainViewModel()
        {
            Tasks = TaskManager.GetTasks();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
            DumpTasksCommand = new RelayCommand(DumpTasks, CanDumpTasks);
            DeleteTaskCommand = new RelayCommand(DeleteTask, CanDeleteTask);
        }

        // Method to determine if task can be deleted (always true here)
        private bool CanDeleteTask(object obj)
        {
            return true;
        }

        // Method to delete tasks marked for deletion
        private void DeleteTask(object obj)
        {
            foreach (var task in Tasks.ToList())
            {
                if (task.ToDelete == true)
                {
                    TaskManager.DeleteTask(task);
                }
            }
            
        }

        // Method to determine if task can be dumped (always true here)
        private bool CanDumpTasks(object obj)
        {
            return true;
        }

        // Method to dump tasks to the debug output
        public void DumpTasks(object obj)
        {
            foreach (var task in Tasks)
            {
                Debug.WriteLine(task.ToString());
            }
        }

        // Method to determine if a new window can be shown (always true here)
        private bool CanShowWindow(object obj)
        {
            return true;
        }

        // Method to show a new task creation window
        private void ShowWindow(object obj)
        {
            var TaskListView = obj as Window;
            CreateTaskView createTaskView = new CreateTaskView();
            createTaskView.Owner = TaskListView;
            createTaskView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            createTaskView.Show();
        }
    }
}
