using System.Windows;
using System.Windows.Controls;
using ToDoApplication.ViewModels;
using Task = ToDoApplication.Models.Task;

namespace ToDoApplication
{
    public partial class MainWindow : Window
    {
        // Constructor to initialise the view and set its data context
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;
        }

        // Event handler for text changes in the filter text box
        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TaskListView.Items.Filter = FilterMethod;
        }

        // Method to filter tasks based on the text in the filter text box
        private bool FilterMethod(object obj)
        {
            var task = (Task)obj;
            return task.Title.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }

        // Event handler for checking the complete toggle
        private void CompleteToggle_Checked(object sender, EventArgs e)
        {
            FilterTextBox.Clear();
            TaskListView.Items.Filter = ShowIncompleteMethod;
        }

        // Method to only show incompelte tasks
        private bool ShowIncompleteMethod(object obj)
        {
            var task = (Task)obj;
            return task.Status.Equals(false);
        }

        // Event handler for unchecking the complete toggle
        private void CompeteToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            TaskListView.Items.Filter = null;
        }
    }
}